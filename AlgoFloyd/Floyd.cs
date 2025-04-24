using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoFloyd
{
    public class Floyd
    {
        public static void DoFloyd()
        {
            string directoryPath = @"C:\Users\egors\OneDrive\Desktop\DataGraph";
            string outputFilePath = @"C:\Users\egors\OneDrive\Desktop\Results.txt";

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("Размерность матрицы (n), Число операций (q), Время работы (t, мс)");

                string[] files = Directory.GetFiles(directoryPath, "*.txt");

                foreach (string filePath in files)
                {
                    Console.WriteLine($"Обработка файла: {Path.GetFileName(filePath)}");
                    int[,] graph = ReadGraphFromFile(filePath);
                    int verticesCount = graph.GetLength(0);
                    (long operations, TimeSpan time) = FloydWarshall(graph, verticesCount);

                    writer.WriteLine($"{verticesCount}; {operations}; {time.TotalMilliseconds}");
                    Console.WriteLine($"Размерность матрицы: {verticesCount}");
                    Console.WriteLine($"Число операций: {operations}");
                    Console.WriteLine($"Время работы: {time.TotalMilliseconds} мс");
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"Результаты записаны в файл: {outputFilePath}");
        }

        static int[,] ReadGraphFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int verticesCount = lines.Length;
            int[,] graph = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                string[] values = lines[i].Split(' ');
                for (int j = 0; j < verticesCount; j++)
                {
                    if (values[j] == "∞")
                    {
                        graph[i, j] = int.MaxValue; //maxvalue - нет ребра
                    }
                    else
                    {
                        graph[i, j] = int.Parse(values[j]);
                    }
                }
            }

            return graph;
        }

        static (long operations, TimeSpan time) FloydWarshall(int[,] graph, int verticesCount)
        {
            int[,] distance = new int[verticesCount, verticesCount];

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    distance[i, j] = graph[i, j];
                }
            }

            // t
            Stopwatch stopwatch = Stopwatch.StartNew();

            //q
            long operationCount = 0;

            //алгоритм
            for (int k = 0; k < verticesCount; k++)
            {
                for (int i = 0; i < verticesCount; i++)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        operationCount += 3;
                        if (distance[i, k] != int.MaxValue && distance[k, j] != int.MaxValue &&
                            distance[i, j] > distance[i, k] + distance[k, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }

            stopwatch.Stop();

            return (operationCount, stopwatch.Elapsed);
        }
    }
}
