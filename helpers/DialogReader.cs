using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstrate.helpers
{
    class DialogReader
    {
        private List<string> introDialog = new List<string>();
        private string line;
        private string finalLine;
        private int dialogCounter = 0;
        private string currentLine = "";
        private string typedLine = "";
        private int textCounter = 0;
        private int enterCount = 1;
        System.IO.StreamReader introFile;

        public DialogReader() { }

        public void getDialog(string fileToRead)
        {

            introFile = new System.IO.StreamReader
                   (fileToRead);

            while ((line = introFile.ReadLine()) != null)
            {
                //_B for breaking the box -- can only fit so much text in box
                if (line.Equals("_B"))
                {
                    introDialog.Add(finalLine);
                    line = introFile.ReadLine();
                    finalLine = "";
                }
                finalLine += line + "\n";
            }

        }

        //need to be two seperate methods here
        public void nextLine()
        {
           
            enterCount++;
            //if they press enter the first time, finish the text
            if(enterCount % 2 == 1)
            {
                textCounter = currentLine.Length;
                typedLine = currentLine;
            }
            else
            {
                if (dialogCounter < introDialog.Count)
                {
                    currentLine = introDialog[dialogCounter];
                    textCounter = 0;
                    typedLine = "";
                }
                dialogCounter++;
            }
         
        }

        public string typeLine(float timer)
        {
            if (timer > 200)
            {
                //adding one letter at a time to the line that is being typed out
                if (textCounter < currentLine.Length)
                {
                    typedLine += currentLine[textCounter];
                }

                //text counter needs to be incremented seperately since we need to know when 
                //we've reached the end of the count
                textCounter++;

                //if the line reaches the end, we want to create a false input for enter
                //and we don't want to increment the textCounter
                if (textCounter == currentLine.Length)
                {
                   enterCount++;
                }
            }
            return typedLine;
        }
            

    }
}
