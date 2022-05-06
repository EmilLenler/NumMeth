using System;
using static System.Math;
using static System.Console;
using System.IO;

public class main{
    public static void Main(){
        Func<vector, double> BreitWigner = delegate(vector v){
            double E = v[0];
            double m = v[1];
            double gamma = v[2];
            double A = v[3];
            return A/((E-m)*(E-m)+gamma*gamma/4);
        };
//Read DATA.txt and save the energies, cross sections and uncertainties in seperate vectors.
        string[] lines = File.ReadAllLines("DATA.txt");
        vector Es = new vector(lines.Length-1);
        vector cross_sec = Es.copy();
        vector uncertainty = Es.copy();
        char[] delimiters = {' ', '\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(int i = 1; i<lines.Length; i++){//Read each line individually. Start at i=1 to ignore the first line of the DATA file
            string line = lines[i];
            var words = line.Split(delimiters,options);
            Es[i-1] = double.Parse(words[0]);
            cross_sec[i-1]=double.Parse(words[1]);
            uncertainty[i-1]=double.Parse(words[2]);
        }
        Func<vector, double> Deviation = delegate(vector v){
            double m = v[0];
            double gamma = v[1];
            double A = v[2];
            double sum = 0;
            for(int i = 0; i<Es.size; i++){
                vector BreitWignerInputVector = new vector(Es[i],m,gamma,A);
                sum+=BreitWigner(BreitWignerInputVector)*BreitWigner(BreitWignerInputVector)/(uncertainty[i]*uncertainty[i]);
            }
            return sum;
        };
    //Now ready to actually do the minimization!
    vector guess = new vector(125,1,1);
    var (RESV,nsteps) = minimization.qnewton(Deviation,guess);
    RESV.print($"Found minimum of deviation after {nsteps} steps at point: (m,Gamma,A) = ");
    WriteLine($"The value of the deviation function in this point is {Deviation(RESV)}");
    
    
    
    
    
    
    }
    
}