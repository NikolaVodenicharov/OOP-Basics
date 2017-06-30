using System;

class Cat : Animal
{
    public override void MakeSound()
    {
        // base.MakeSound();
        Console.WriteLine("mqu");
    }


    /*  this is bad, but can be used
    public new void MakeSound()
    {

    }
    */
}

