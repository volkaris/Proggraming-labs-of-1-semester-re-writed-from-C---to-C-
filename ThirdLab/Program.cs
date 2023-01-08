using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;


namespace BitmapExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            void SetPixels(ref int height_, ref int lenght_, ref int[,] arr_, ref Bitmap image_)
            {

                for (int i = 0; i < height_; i++)
                {
                    for (int j = 0; j < lenght_; j++)
                    {
                        if (arr_[i, j] == 0)
                        {
                            image_.SetPixel(i, j, Color.White);
                        }
                        else if (arr_[i, j] == 1)
                        {
                            image_.SetPixel(i, j, Color.Green);
                        }
                        else if (arr_[i, j] == 2)
                        {
                            image_.SetPixel(i, j, Color.Violet);
                        }
                        else if (arr_[i, j] == 3)
                        {
                            image_.SetPixel(i, j, Color.Yellow);
                        }
                        else if (arr_[i, j] > 3)
                        {
                            image_.SetPixel(i, j, Color.Black);
                        }
                    }

                }

            }

            void SandPileMath(ref int height, ref int lenght, ref int[,] arr, ref int amount_of_iteration, int frequency, string output_, int max_iter_)
            {
            go:
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < lenght; j++)
                    {
                        if (arr[i, j] > 3)
                        {
                            arr[i, j] -= 4;

                            if (j != lenght - 1)
                            {
                                arr[i, j+1]+= 1;
                            }

                            if (j > 0)
                            {
                                arr[i, j-1] += 1;
                            }

                            if (i != height - 1)
                            {
                                arr[i+1, j] += 1;
                            }

                            if (i > 0)
                            {
                                arr[i-1, j] += 1;
                            }
                            amount_of_iteration += 1;
                            //if (amount_of_iteration<max_iter_)
                            //{
                            //    goto end;
                            //}
                        }
                    }

                    if (amount_of_iteration%frequency==0 && frequency!=0)
                    {
                        Bitmap image__ = new Bitmap(height, lenght, PixelFormat.Format24bppRgb);
                        SetPixels(ref height, ref lenght, ref arr, ref image__);
                        image__.Save(output_+"\\picture№"+Convert.ToString(amount_of_iteration)+".bmp");
                    }
                }
                for (int k = 0; k < height; k++)
                {
                    for (int q = 0; q < lenght; q++)
                    {
                        if (arr[k, q] > 3)
                        {
                            goto go;
                        }
                    }
                }

            end:
                {
                    _ = 1;
                }
            }

            void ReadFromTSV(string TSVPath, ref int[,] arr___)
            {
                StreamReader reader = new StreamReader(TSVPath.Substring(1), Encoding.ASCII);
                reader.BaseStream.Position = 0;
                while (true)
                {
                    string str = reader.ReadLine();
                    if (str == null) //достигнут конец файла
                    {
                        break;
                    }

                    string[] arr_1 = str.Split('\t');
                    //  int[] arr_= {0,0,0};

                    arr___[Convert.ToInt32(arr_1[0]), Convert.ToInt32(arr_1[1])]=Convert.ToInt32(arr_1[2]);
                }
            }

            int height__ = 500;
            int lenght__ = 500;
            int frequency_ = 20;
            string output = "D:\\c#\\ThirdLab\\123";
            int max_iter = 0;
            int amount_of_iteration_ = 0;
            string TSV = null;
            void Parse()
            {
                for (int i = 0; i<args.Length; i++)
                {
                    if (args[i]=="--lenght" || args[i]=="-l")
                    {
                        lenght__=Convert.ToInt32(args[i+1]);
                    }
                    else if (args[i]=="--width" || args[i]=="-w")
                    {
                        height__=Convert.ToInt32(args[i+1]);
                    }
                    else if (args[i]=="--freq" || args[i]=="-f")
                    {
                        frequency_=Convert.ToInt32(args[i+1]);
                    }
                    else if (args[i]=="--output" || args[i]=="-o")
                    {
                        output=args[i+1];
                    }
                    else if (args[i]=="--max_iter" || args[i]=="-m")
                    {
                        max_iter=Convert.ToInt32(args[i+1]);
                    }
                    else if (args[i]=="--input" || args[i]=="-i")
                    {
                        TSV=args[i+1];
                    }

                }
            }

            Parse();

            int[,] arr__ = new int[lenght__, height__];

            ReadFromTSV(TSV, ref arr__);

            SandPileMath(ref height__, ref lenght__, ref arr__, ref amount_of_iteration_, frequency_, output, max_iter);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");

        }
    }
}


