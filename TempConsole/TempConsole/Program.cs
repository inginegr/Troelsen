using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace TempConsole
{
    class Program
    {
        class LocPart
        {
            //Изображение
            Image img { get; set; }

            //Размеры ячейки
            int Height;
            int Width;

            //Количество строк или столбцов в ячейке
            int CellNumbers;

            //Ячейка разбита на строки или столбцы
            bool IsRowed;
            bool IsColumned; 

            //Массив ячеек с изображениями
            LocPart[] parts = null;

            //Вставить строки в ячейку
            public LocPart[] AddRows(int rowNumber)
            {
                CellNumbers = rowNumber;
                IsColumned = false;
                IsRowed = true;
                return AddParts(rowNumber);
            }

            //Вставить столбцы в ячейку
            public LocPart[] AddColumns(int columnNumber)
            {
                CellNumbers = columnNumber;
                IsColumned = true;
                IsRowed = false;
                return AddParts(columnNumber);
            }

            //Создать дочерние ячейки
            LocPart[] AddParts(int partsNumber)
            {
                parts = parts ?? new LocPart[partsNumber];
                for (int i = 0; i < partsNumber; i++)
                    parts[i] = parts[i] ?? new LocPart(IsRowed ? (Height / partsNumber) : Height, IsColumned ? Width / partsNumber : Width);
                return parts;
            }

            //Добавить изображение в ячейку
            public void AddImage(string imgPath)
            {
                if (IsRowed || IsColumned)
                    throw new Exception("Разрешено добавлять изображения только в неразбитые (элементарные) ячейки");
                else
                {
                    try
                    {
                        img = Image.FromFile(imgPath);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }

            //Вывести все изображения на экран
            //orientationFlag = true выводим изображения по строкам, false - выводим изображения по столбец
            public void DisplayImage(int widthParam, int paddingLeft = 0, int paddingTop = 0, int paddingRight = 0, int paddingBottom = 0, bool? orientationFlag = null)
            {
                if(IsColumned || IsRowed)
                {
                    foreach (LocPart l in parts)
                    {
                        l.DisplayImage(widthParam, paddingLeft, paddingTop, paddingRight, paddingBottom, IsRowed ? true : false);
                    }                        
                }
                else
                {
                    if(orientationFlag)
                }
            }
            
            public LocPart() { }

            public LocPart(int heightParam, int widthParam)
            {
                CellNumbers = 1;
                Height = heightParam;
                Width = widthParam;
            }
        }

        LocPart[] SetSplitting()
        {

            return new LocPart[5];
        }
        static void Main(string[] args)
        {
            //Image image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");
            LocPart loc = new LocPart(500, 600);
            loc.AddColumns(3);
            loc.AddColumns(3)[0].AddImage(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
            loc.AddColumns(3)[1].AddImage(@"C:\Users\Public\Pictures\Sample Pictures\Chrysanthemum.jpg");

            Console.ReadLine();
        }
    }
}