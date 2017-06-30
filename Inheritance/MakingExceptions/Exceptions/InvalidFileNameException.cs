using System;

class InvalidFileNameException : Exception
{
    private const string ForbiddenSymbolInName = "The given name contains symbols that are not allowed to be used in names of  filesor folders.";


    public InvalidFileNameException()
        :base (ForbiddenSymbolInName)
    {

    }

    public InvalidFileNameException(string message)
        :base (message)
    {

    }
}