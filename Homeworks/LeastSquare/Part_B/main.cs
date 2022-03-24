using static System.Math;
using static System.Console;
using System.IO;
using System;
public class main{
    public static void Main(){
        var readData = new StreamReader("data.txt");
        var fs = new Func<double,double>[] {z=>1.0, z=>-z};
        var writeData = new StreamWriter("CleanData.txt");
        //Below for-loop formats the data.txt file such that it gets rid of all non-doubles.
        //The Cleaned data is put into CleanData.txt¨
        for(string line=readData.ReadLine(); line!=null; line=readData.ReadLine()){
            string[] bits =line.Split(' ',',',':');
            int Index =0;
            double number;
            int NoDoubs =0;
            foreach(string str in bits){
                if(Double.TryParse(str, out number)){
                NoDoubs++;
                }
            }
            double[] DataLine = new double[NoDoubs];
            foreach(string str in bits){
                if(Double.TryParse(str,out number)){
                    DataLine[Index]=double.Parse(str);
                    Index++;
                }
            }
            for(int j=0; j<DataLine.Length; j++){
            writeData.Write($"{DataLine[j]} ");
            }
            writeData.WriteLine();
        }
    readData.Close();
    writeData.Close();
    // Get number of elements in a line (should be same for all lines, so only do 1st).
    var readClean = new StreamReader("CleanData.txt");
    string Line0 = readClean.ReadLine();
    var options = StringSplitOptions.RemoveEmptyEntries;
    string[] nos = Line0.Split(' ','\n',options);
    readClean.Close();
    //Make DataArray that will hold all Data Numbers 3 lines (t,y,dy) with variable length depending on the input data file.
    double[,] DataArray = new double[3,nos.Length];
    using (var sr = new StreamReader("CleanData.txt"))
        for(int i=0; i<DataArray.GetLength(0); i++){
        string line= sr.ReadLine();
        string[] nums = line.Split(' ',options);
        for(int j=0; j<DataArray.GetLength(1); j++){
            DataArray[i,j] = double.Parse(nums[j]);
        }
    }
    matrix Data = new matrix(3,nos.Length);
    for(int j = 0; j<Data.size1; j++){
        for(int i=0; i<Data.size2; i++){
            if(j==1){
                Data[j,i] =Log(DataArray[j,i]);
            }
            else{
            Data[j,i] =DataArray[j,i];}
        }
    }
    Data.print("Data =");
    vector c = fit.fitter(fs,Data);
    c.print("c =");

    var DatOut = new StreamWriter("DataOut.txt");
    for(int j=0; j<nos.Length; j++){
        DatOut.WriteLine($"{DataArray[0,j]} {Log(DataArray[1,j])} {DataArray[2,j]/DataArray[1,j]}");
    }
    DatOut.Close();
    var FitOut = new StreamWriter("FitOut.txt");
    for(double x= 0; x<=20;x+=0.1){
        FitOut.WriteLine($"{x} {c[0]-c[1]*x}");
    }
    FitOut.Close();

    matrix Cov = fit.Cov(fs,Data);
    Cov.print("Covariance matrix is:");
    for(int i=0; i<Cov.size1;i++){
        WriteLine($"Uncertainty of c({i}) is {Sqrt(Cov[i,i])} (Index starts at 0)");
    }
    double halflife = Log(2)/c[1];
    WriteLine($"Fitted halflife is {halflife} days");
    //By error propagation uncertainty in x = u/v where v has some uncertainty dv then dx should be x*(du/u)
    double delta_hl = halflife*(Sqrt(Cov[1,1])/c[1]);
    WriteLine($"Uncertainty in half-life is {delta_hl} days");
    double RealHL = 3.6;
    bool Halflife_OK = halflife-delta_hl<=RealHL | halflife+delta_hl>=RealHL;
    WriteLine($"From internet Ra224 half-life is 3.6 days. Is fitted value +/- uncertainty OK? {Halflife_OK}");

}
}