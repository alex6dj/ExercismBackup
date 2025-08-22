public static class Say
{
    public static string InEnglish(long number)
    {
        if (number < 0 || number > 999999999999)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 0 and 999,999,999,999.");
        }
        
        if (number == 0)
        {
            return "zero";
        }   
        
        string[] units =
        [
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                           "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        ];
        
        string[] tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
        
        string[] scales = ["", "thousand", "million", "billion"];
        
        string words = "";
        int scaleIndex = 0;
        
        while (number > 0)
        {
            int chunk = (int)(number % 1000);
            number /= 1000;

            if (chunk != 0)
            {
                string chunkWords = "";

                int hundreds = chunk / 100;
                if (hundreds > 0)
                {
                    chunkWords += units[hundreds] + " hundred";
                }

                int remainder = chunk % 100;
                if (remainder > 0)
                {
                    if (hundreds > 0)
                    {
                        chunkWords += " ";
                    }

                    if (remainder < 20)
                    {
                        chunkWords += units[remainder];
                    }
                    else
                    {
                        int tensPlace = remainder / 10;
                        int unitsPlace = remainder % 10;
                        chunkWords += tens[tensPlace];
                        if (unitsPlace > 0)
                        {
                            chunkWords += "-" + units[unitsPlace];
                        }
                    }
                }

                if (scaleIndex > 0)
                {
                    chunkWords += " " + scales[scaleIndex];
                }

                if (words.Length > 0)
                {
                    words = chunkWords + " " + words;
                }
                else
                {
                    words = chunkWords;
                }
            }

            scaleIndex++;
        }

        return words;
    }
}