using System;
using static System.Math;
using System.IO;
using static System.Console;

public class main{
    public static void Main(){
        matrix GS_Energies = new matrix(4,4);
        matrix VecMatFin = new matrix(40,40);
        matrix HDiagFin = new matrix(40,40);
        matrix HFin = new matrix(40,40);
        vector rfin = new vector(40);
        //Outer loop here is npoints, inner loop is rmax.
        for(int pointmultiplier=1; pointmultiplier<=4;pointmultiplier++){
            for(int rmaxmultiplier=1;rmaxmultiplier<=4;rmaxmultiplier++){
        //Build Hamiltonian!
        //First K
        int npoints = 10*pointmultiplier;
        double rmax = 10*rmaxmultiplier, dr = rmax/(npoints+1);
        WriteLine($"Doing run with {npoints} points and rmax = {rmax}.");
        vector r = new vector(npoints);
        for(int i=0; i<npoints; i++)r[i]=dr*(i+1);
        matrix H =new matrix(npoints,npoints);
        for(int i=0; i<npoints-1; i++){
            matrix.set(H,i,i,-2);
            matrix.set(H,i,i+1,1);
            matrix.set(H,i+1,i,1);
        }
        matrix.set(H,npoints-1,npoints-1,-2);
        H*=-0.5/dr/dr;
        //Now V
        for(int i=0; i<npoints; i++)H[i,i]+=-1/r[i];
        //Prepare eigenvector matrix
        matrix VecMat = new matrix(npoints,npoints);
        for(int i=0; i<npoints; i++){
            VecMat[i,i]=1;
        }
        matrix HDiag=H.copy();
        diagonalization.JacobiDiag(HDiag,VecMat);
        double tolerance =1e-6;
        WriteLine($"Is hamiltonian succesfully diagonalized (tolerance = {tolerance})?");
        int errorcount =0;
        for(int i=0; i<npoints; i++){
            for(int j=0; j<npoints; j++){
                if(j!=i && Abs(HDiag[i,j])>tolerance){
                    WriteLine($"Not diagonal! Off-diagonal element [{i},{j}] is nonzero!!!");
                    errorcount++;
                }
            }
        }
        WriteLine($"Number of non-zero off-diagonal elements is {errorcount}! Should be zero for succesful diagonalization");
        vector eigenvals =new vector(npoints);
        for(int i= 0; i<npoints;i++)eigenvals[i]=HDiag[i,i];
        vector GS = VecMat[0];
        vector test = H*GS/eigenvals[0];
        bool istest =vector.approx(GS,test,1e-6,1e-6);
        WriteLine($"Is Ground state eigenvector of H with eigenvalue {eigenvals[0]}? {istest}");
        GS.print("Ground state vector is ");
        GS_Energies[pointmultiplier-1,rmaxmultiplier-1] = eigenvals[0];
        //From just looking at the plots it seems like the ground state wavefunction is essentially flat beyond rmax = 10, so choose this for the plot.
        //THis also gives the GS energy closest to the anlaytical one which is -0.5. Of course this also makes sense as we get the most points
        //describing the wavefunction in the place that matters the most (which is closer to the nucleus.)
        //This is of course a less good idea for higher excited states, whose amplitudes extend fruther.
        if(pointmultiplier==4 && rmaxmultiplier ==1){
            VecMatFin = VecMat.copy();
            HDiagFin=HDiag.copy();
            HFin=H.copy();
            rfin=r.copy();
        }
            }
        }
        GS_Energies.print("Ground state energy check matrix for looking at convergence, rows correspond to 10,20,30,40 points, columns to rmax = 10,20,30,40");
        var DataOut = new StreamWriter("DataOut.txt");
        vector Ground = VecMatFin[0];
        vector GSp1 = VecMatFin[1];
        vector GSp2 = VecMatFin[2];
        for(int i=0; i<rfin.size; i++)
        DataOut.WriteLine($"{rfin[i]} {Ground[i]} {GSp1[i]} {GSp2[i]}");
        DataOut.Close();
    }
}