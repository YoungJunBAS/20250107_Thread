using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace _20250107_Thread
{
    public partial class Form1 : Form
    {
        ProgressBar[] progress_arr = new ProgressBar[5];
        Thread[] threads = new Thread[5];
        int[] timeTable = new int[5];

        public Form1()
        {
            InitializeComponent();

            progress_arr[0] = progressBar1;
            progress_arr[1] = progressBar2;
            progress_arr[2] = progressBar3;
            progress_arr[3] = progressBar4;
            progress_arr[4] = progressBar5;

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                int index = i;
                threads[index] = new Thread(() => RaceTheCar(progress_arr[index], index)); // 람다식은 매개변수를 떼우고, 원하는 메소드를 실행하게 한다.
                threads[index].Start();
            }


            //Thread thread1 = new Thread(() => RaceTheCar(progressBar1));
            //Thread thread2 = new Thread(() => RaceTheCar(progressBar2));
            //Thread thread3 = new Thread(() => RaceTheCar(progressBar3));
            //Thread thread4 = new Thread(() => RaceTheCar(progressBar4));
            //Thread thread5 = new Thread(() => RaceTheCar(progressBar5));

            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start();
            //thread5.Start();            
        }
        private void RaceTheCar(ProgressBar progressBar, int index)
        { 
            int cnt = 0;
            int sumTime = 0;
            for (int i = 0; i <= 100; i++)
            {
                // 자동차 경주 로직 (예: 랜덤한 시간 동안 대기)
                int randomSleep = new Random().Next(100, 1001);
                Thread.Sleep(randomSleep);

                // UI 스레드에 ProgressBar 값 업데이트 요청 (Invoke 사용)
                if (progressBar.InvokeRequired)
                {
                    // Invoke를 발생시켜서 간접적으로 컨트롤을 업데이트
                    progressBar.Invoke(new MethodInvoker(() =>
                    {
                        progressBar.Value = i;
                    }));
                }
                sumTime += randomSleep;
                cnt++;
            }
            //MessageBox.Show("No." + (index + 1) + "의 도착시간 : " + sumTime + "ms");
            timeTable[index] = sumTime;
        }
    }
}
