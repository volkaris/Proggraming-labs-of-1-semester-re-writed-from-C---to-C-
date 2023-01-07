using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace BitmapExample
{
	class Program
	{

		static void Main(string[] args)
		{
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            void SetPixels(ref int height_,ref int lenght_,ref int[,] arr_,ref Bitmap image_)
            {  
				//Bitmap image_ = new Bitmap(lenght_, height_,PixelFormat.Format32bppRgb);
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
				//amount_of_pictures++;
                //image_.Save("image"+Convert.ToString(amount_of_pictures)+".bmp");
            }
    
           void SandPileMath(ref int height, ref int lenght, ref int[,] arr,ref int amount_of_iteration ,int frequency)
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
                           
                        }
                    }

                    if (amount_of_iteration%frequency==0)
                    {
                        Bitmap image__ = new Bitmap(height, lenght, PixelFormat.Format24bppRgb);
                        SetPixels(ref height, ref lenght, ref arr, ref image__);
                        image__.Save("picture№"+Convert.ToString(amount_of_iteration)+".bmp");
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
            }
			
            void Print(ref int[,] arr, ref int height_, ref int lenght_)
            {
                for(var i = 0; i<lenght_; i++)
                {
                    for (var j = 0; j<height_; j++)
                    {
                        Console.Write(arr[i, j]);
                    }
                    Console.WriteLine();
                }
            }
           
            var height__ = 200;
			var lenght__ = 200;
            int[,] arr__ = new int[lenght__, height__];
            arr__[100,100]=40000;
            const int frequency_ = 10000;
            int amount_of_iteration_ = 0;
            
            SandPileMath(ref height__, ref lenght__, ref arr__,ref amount_of_iteration_, frequency_);


            Bitmap image___ = new Bitmap(height__, lenght__, PixelFormat.Format24bppRgb);
            SetPixels(ref height__, ref lenght__, ref arr__, ref image___);
            image___.Save("this_is_the_last_file.bmp");
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime, "RunTime");
            
        }
		}
	}


