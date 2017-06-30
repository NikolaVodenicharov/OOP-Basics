﻿using System;

class DuplicateEntryInStructureException : Exception
{
    private const string DuplicateEntry = "The {0} already exist in {1}";

    public DuplicateEntryInStructureException(string message)
        :base(message)
    {

    }

    public DuplicateEntryInStructureException(string entry, string structure)
        :base(string.Format(DuplicateEntry, entry, structure))
    {

    }
}

