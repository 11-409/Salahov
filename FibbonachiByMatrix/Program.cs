int FibbonachiByMatrix(int degree)
{

    if (degree == 0)
    {
        return 0;
    }
    if (degree == 1)
    {
        return 1;
    }

    int[,] fibbonachiMatrix = new int[2, 2] { { 1, 1 }, { 1, 0 } };
    int[,] resultMatrix = FindMatrixForFibbonachi(degree-1, fibbonachiMatrix); //degree-1 потому что в начале уже имеем первую степень
   
    return resultMatrix[0,0];
}

int[,] FindMatrixForFibbonachi(int degree, int[,] fibbMatrix)
{
    int[,] resultMatrix = new int[2, 2] { { 1, 0 }, { 0 , 1} }; //заглушка - чтобы сохрянять fibbonachi при нечетной степени
    while (degree > 0)
    {
        if (degree % 2 == 1)
        {
            resultMatrix = MultiplyMatrix(resultMatrix, fibbMatrix); // вот сохранили 
        }
        
        degree = degree / 2; 
        fibbMatrix = ExponentiationMatrix(fibbMatrix);  
    }

    return resultMatrix;
}


int[,] ExponentiationMatrix(int[,] matrix)
{
    int[,] resultMatrix = new int[2, 2];
    for (int i = 0; i < 2; i++)
    {
        for (int j = 0; j < 2; j++) 
        {
            for (int k = 0; k < 2; k++) 
            {
                resultMatrix[i, j] += matrix[i, k] * matrix[k, j];
            }
        }
    }
    return resultMatrix;
}

int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[2, 2];
    for (int i = 0; i < 2; i++) 
    {
        for (int j = 0; j < 2; j++)
        {
            for (int k = 0; k < 2; k++) 
            {
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return resultMatrix;
}