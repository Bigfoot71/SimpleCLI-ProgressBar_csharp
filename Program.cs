using System;

using System.Threading; // Only for demo: Thread.Sleep()

namespace ProgressBar
{
    class ProgressBarDemo
    {
        static void Main(string[] args)
        {
            ProgressBar pg = new ProgressBar();

            pg.Start();     // start/show progressbar

            for (int i=1; i<=100; i++)
            {
                pg.Progress(i); Thread.Sleep(100);
            }
        }
    }

    class ProgressBar
    {
        
        public string Title;
        private string BarString;
        private char CharFull, CharEmpty;
        private int EndValue;


        public ProgressBar(string title = "Progress", char charFull = '#', char charEmpty = ' ', int endValue = 100)
        {
            Title = title;
            CharFull = charFull;
            CharEmpty = charEmpty;
            EndValue = endValue;
        }

        public void Start()
        {
            this.Construct();
            Console.Write(BarString);
        }


        public void Progress(int value)
        {
            this.Construct(value);
            Console.Write($"\r{BarString}");
        }

        /*  

        // Optional for better readability of your code \\
        
        public void Finish()
        {
            this.Construct(EndValue);
            Console.Write($"\r{BarString}");
        }
        
        */

        private void Construct(int value = 0)
        {

            if (value > EndValue)
                value = EndValue;

            BarString = $"{Title} - [{value}/{EndValue}][";

            int bufferWidth = Console.BufferWidth;
            int barStringLenght = BarString.Length+1;
            
            double loadAeraSize = bufferWidth-barStringLenght;   // Taille de la zone de barre de chargement
            double loadBlockSize = loadAeraSize/EndValue;        // Taille d'un bloc de la barre
            double yesLoadSize = value*loadBlockSize;            // Taille de la partie chargée de la barre
            double noLoadSize = loadAeraSize-yesLoadSize;        // Taille de la partie non chargée de la barre
            
            if (value > 0)
            {
                for (int i=0; i<yesLoadSize; ++i)
                {
                    BarString += CharFull;
                }
            }

            for (int i=1; i<noLoadSize; ++i)
            {
                BarString += CharEmpty;
            }
            
            BarString += "]";

            if (value == EndValue)
                BarString += "\n";

        }
    }
}
