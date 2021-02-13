using System;

namespace randstr
{
    class Creator
    {
        private int minStringLen;
        private int maxStringLen;
        private int stringsNumber;
        private string charPool;
        private Random random;
        private string[] resultStrings;
        public string[] ResultStrings
        {
            get
            {
                return resultStrings;
            }
        }
        

        public Creator(int minLen, int maxLen, int number, string pool, int seed)
        {
            minStringLen = minLen;
            maxStringLen = maxLen;
            stringsNumber = number;
            charPool = pool;
            random = new Random(seed);
        }

        public Creator(int minLen, int maxLen, int number, string pool)
        {
            minStringLen = minLen;
            maxStringLen = maxLen;
            stringsNumber = number;
            charPool = pool;
            random = new Random();
        }

        public void Create()
        {
            resultStrings = new string[stringsNumber];
            for (int stringIt = 0; stringIt < stringsNumber; stringIt++)
            {

                resultStrings[stringIt] = new string(CreateRandomArray());
            }
        }

        private char[] CreateRandomArray()
        {
            int randomSringLen = random.Next(minStringLen, maxStringLen);
            char[] randomChars = new char[randomSringLen];
            for (int charIt = 0; charIt < randomSringLen; charIt++)
            {
                int randCharInPool = random.Next(charPool.Length-1);
                randomChars[charIt] = charPool[randCharInPool];
            }
            return randomChars;
        }
    }
}
