namespace AOC2021Day3
{
    public class PowerConsumption
    {
        public List<string> InputData { get; }

        public PowerConsumption(List<string> inputData)
        {
            InputData = inputData;
        }
        public int GetGammaRate()
        {
            var stringResult = "";

            var transposedData = TransposeInputData(InputData);

            foreach (var line in transposedData)
            {
                var count0 = line.Count(l => l == '0');
                var count1 = line.Count(l => l == '1');

                if (count0 > count1)
                    stringResult += '0';
                else
                    stringResult += '1';
            }

            return Convert.ToInt32(stringResult, 2);
        }

        public int GetEpsilonRate()
        {
            var stringResult = "";

            var transposedData = TransposeInputData(InputData);

            foreach (var line in transposedData)
            {
                var count0 = line.Count(l => l == '0');
                var count1 = line.Count(l => l == '1');

                if (count0 < count1)
                    stringResult += '0';
                else
                    stringResult += '1';
            }

            return Convert.ToInt32(stringResult, 2);
        }

        public int GetOxygenGeneratorRating()
        {
            var inputData = InputData;
            var i = 0;

            while (inputData.Count > 1)
            {
                var transposedData = TransposeInputData(inputData);
                var bitCriteria = GetMostCommonValue(transposedData[i]);

                var stringResult = new List<string>();
                foreach (var line in inputData)
                {
                    if (line[i] == bitCriteria)
                        stringResult.Add(line);
                }
                inputData = stringResult;
                i++;
            }
            var result = inputData[0];

            return Convert.ToInt32(result, 2);
        }

        public int GetCo2ScrubberRating()
        {
            var inputData = InputData;
            var i = 0;

            while (inputData.Count > 1)
            {
                var transposedData = TransposeInputData(inputData);
                var bitCriteria = GetLeastCommonValue(transposedData[i]);

                var stringResult = new List<string>();
                foreach (var line in inputData)
                {
                    if (line[i] == bitCriteria)
                        stringResult.Add(line);
                }
                inputData = stringResult;
                i++;
            }
            var result = inputData[0];

            return Convert.ToInt32(result, 2);
        }
        private char GetMostCommonValue(string line)
        {
            var count0 = line.Count(l => l == '0');
            var count1 = line.Count(l => l == '1');

            if (count0 > count1)
                return '0';
            else
                return '1';
        }

        private char GetLeastCommonValue(string line)
        {
            var count0 = line.Count(l => l == '0');
            var count1 = line.Count(l => l == '1');

            if (count0 <= count1)
                return '0';
            else
                return '1';
        }
        private List<string> TransposeInputData(List<string> inputData)
        {
            var result = new List<string>();

            var heigth = inputData.Count();
            var width = inputData[0].Length;

            for (var i = 0; i < width; i++)
            {
                var newLine = "";
                foreach(var line in inputData)
                {
                    newLine += line[i];
                }

                result.Add(newLine);
            }

            return result;
        }
    }
}
