using System.Collections.Generic;

namespace SantaClauseConsoleApp
{
    public sealed class LetterRepository
    {
        public List<Letter> letterList { get; set; }

        private static LetterRepository _instace;

        private LetterRepository()
        {
            this.letterList = new List<Letter>();
        }
        

        public static LetterRepository Instace
        {
            get
            {
                if (_instace == null)
                {
                    _instace = new LetterRepository();
                }

                return _instace;
            }
        }

        public void addLetter(Letter letter)
        {
            _instace.letterList.Add(letter);
        }

        public void printLetterByChildID(int ID)
        {
            foreach (Letter variableLetter in _instace.letterList)
            {
                if (variableLetter.sender.ID == ID)
                {
                    variableLetter.createTextLetter();
                }
            }
        }
    }
}