using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _20250107_TaskAsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\dudwn\\Desktop\\스마트팩토리SW과정\\4주차\\accounts.txt";

            try
            {
                string fileContent = await ReadTextFileAsync(filePath);
                //Console.WriteLine(fileContent);
                textBox1.Text = fileContent; 
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        async Task<string> ReadTextFileAsync(string filePath)
        {
            using (var streamReader = new StreamReader(filePath))
            {
                return await streamReader.ReadToEndAsync();
            }
        }
    }
}
