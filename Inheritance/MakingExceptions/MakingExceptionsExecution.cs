using System;

class MakingExceptionsExecution
{
    static void Main()
    {

        try
        {

        }
        catch (FieldAccessException e)
        {
            throw new FieldAccessException(e.Message)
            throw;
        }
    }
}

