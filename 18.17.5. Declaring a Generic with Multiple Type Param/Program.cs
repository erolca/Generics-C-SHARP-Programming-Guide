using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IPair<TFirst, TSecond>
{
    TFirst First
    { get; set; }
    TSecond Second
    { get; set; }
}

public struct Pair<TFirst, TSecond> : IPair<TFirst, TSecond>
{
    public Pair(TFirst first, TSecond second)
    {
        _First = first;
        _Second = second;
    }

    public TFirst First
    {
        get { return _First; }
        set { _First = value; }
    }
    private TFirst _First;

    public TSecond Second
    {
        get { return _Second; }
        set { _Second = value; }
    }
    private TSecond _Second;
}

class Program
    {
        static void Main(string[] args)
        {
        }
    }

