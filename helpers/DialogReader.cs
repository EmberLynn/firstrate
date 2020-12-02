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

        //called when enter is pressed.  Will finish typing the line if it is not done, else it will get the next line to be printed
        public void nextLine()
        {
           
            enterCount++;
            //if they press enter the first time, finish the text
            if(enterCount % 2 == 1)
            {
                textCounter = currentLine.Length;
                typedLine = currentLine;
            }
            //if the current line is done printing, get the next line
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

        //prints the line to the screen character by character or prints the entire line if enter was pressed prior
        public string typeLine(float timer)
        {
            if (timer > 200)
            {
                //adding one letter at a time to the line that is being typed out
                //won't happen if the entire line has already been printed, but instead typedLine
                //value aquired from nextLine method will be returned (which is the entire line)
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

            //returns either the line being typed or the entire typed line depending of if enter was pressed or not
            return typedLine;
        }
            
        //need to be able to tell when we've reacched the end of the dialog array so we can unlock
        //character animation and reset the dialog.
        public bool isDialogDone()
        {
            if (dialogCounter == introDialog.Count+1)
                return true;

            return false;
        }

    }
}
