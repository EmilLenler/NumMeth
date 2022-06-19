NAME : Emil Lenler-Eriksen
STUDENT ID: 201708315
I've implemented the two-sided Jacobi algorithm for SVD via a class defined in SVD_TWO_JACOBI.cs. The class contains the U,D and V matrices of the decomposition
as described on the website as well as an int called "sweeps" which counts the number of sweeps for the diagonalization.
To ensure validity I print all of U, D and V to look for any glaring mistakes. Primarily I've ensured over multiple runs that D is a positive diagonal matrix.
Furthermore I ensure that U*D*V^T = A by using the matrix.approx() method, I also check the orthogonality of U and V by multiplying each with their own transpose.
Finally I do a loop over matrix sizes where I time how long it takes to perform the decomposition depending on the size of the matrix. The results of this are seen in timeplot.png
If I were to grade my own work I would say that it roughly corresponds to having performed parts A and B of a homework and therefore I'd give my work a 9/10 rating. 