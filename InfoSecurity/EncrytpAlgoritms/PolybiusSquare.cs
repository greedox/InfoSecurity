using System;

namespace InfoSecurity.EncrytpAlgoritms
{
    public enum Method
    {
        Method1,
        Method2
    }

    class PolybiusSquare : IEncryptable
    {
        char[,] square;
        string alphabet;
        Method encryptMethod;

        private string key;
        public string Key 
        { 
            get => key;
            set
            {
                key = value;
            }
        }

        public PolybiusSquare(string key, string alphabet = null, Method cipherMethod = Method.Method1)
        {
            string alph = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            this.alphabet = alphabet ?? (alph + alph.ToLower() + " ");
            encryptMethod = cipherMethod;
            Key = key;
        }

        //возвращает квадрат Полибия
        char[,] GetSquare(string key)
        {
            var newAlphabet = alphabet;
            //удаляем из алфавита все символы которые содержит ключ
            for (int i = 0; i < key.Length; i++)
            {
                newAlphabet = newAlphabet.Replace(key[i].ToString(), "");
            }

            //добавляем пароль в начало алфавита, а в конец дополнительные знаки
            //для того чтобы избежать пустых ячеек
            newAlphabet = key + newAlphabet + "0123456789!@#$%^&*)_+-=<>?,.";

            //получаем размер стороны квадрата
            //округлением квадратного корня в сторону большего целого числа
            var n = (int)Math.Ceiling(Math.Sqrt(alphabet.Length));

            //создаем и заполняем массив
            square = new char[n, n];
            var index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (index < newAlphabet.Length)
                    {
                        square[i, j] = newAlphabet[index];
                        index++;
                    }
                }
            }

            return square;
        }

        //поиск символа в двухмерном массиве
        bool FindSymbol(char[,] symbolsTable, char symbol, out int column, out int row)
        {
            var l = symbolsTable.GetUpperBound(0) + 1;
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (symbolsTable[i, j] == symbol)
                    {
                        //значение найдено
                        row = i;
                        column = j;
                        return true;
                    }
                }
            }

            //если ничего не нашли
            row = -1;
            column = -1;
            return false;
        }

        public string Encrypt(string plainMessage)
        {
            var outputText = "";
            var square = GetSquare(key);
            switch (encryptMethod)
            {
                case Method.Method1:
                    for (int i = 0; i < plainMessage.Length; i++)
                    {
                        if (FindSymbol(square, plainMessage[i], out int columnIndex, out int rowIndex))
                        {
                            var newRowIndex = rowIndex == square.GetUpperBound(1)
                                ? 0
                                : rowIndex + 1;
                            outputText += square[newRowIndex, columnIndex].ToString();
                        }
                    }
                    break;

                case Method.Method2:
                    var m = plainMessage.Length;
                    var coordinates = new int[m * 2];
                    for (int i = 0; i < m; i++)
                    {
                        if (FindSymbol(square, plainMessage[i], out int columnIndex, out int rowIndex))
                        {
                            coordinates[i] = columnIndex;
                            coordinates[i + m] = rowIndex;
                        }
                    }

                    for (int i = 0; i < m * 2; i += 2)
                    {
                        outputText += square[coordinates[i + 1], coordinates[i]];
                    }
                    break;
            }

            return outputText;
        }

        public string Decrypt(string encryptedMessage)
        {
            var outputText = "";
            var square = GetSquare(key);
            var m = encryptedMessage.Length;
            switch (encryptMethod)
            {
                case Method.Method1:
                    for (int i = 0; i < m; i++)
                    {
                        if (FindSymbol(square, encryptedMessage[i], out int columnIndex, out int rowIndex))
                        {
                            var newRowIndex = rowIndex == 0
                                ? square.GetUpperBound(1)
                                : rowIndex - 1;
                            outputText += square[newRowIndex, columnIndex].ToString();
                        }
                    }
                    break;

                case Method.Method2:
                    var coordinates = new int[m * 2];
                    var j = 0;
                    for (int i = 0; i < m; i++)
                    {
                        if (FindSymbol(square, encryptedMessage[i], out int columnIndex, out int rowIndex))
                        {
                            coordinates[j] = columnIndex;
                            coordinates[j + 1] = rowIndex;
                            j += 2;
                        }
                    }

                    for (int i = 0; i < m; i++)
                    {
                        outputText += square[coordinates[i + m], coordinates[i]];
                    }
                    break;
            }

            return outputText;
        }
    }
}
