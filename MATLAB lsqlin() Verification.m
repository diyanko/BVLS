opts = delimitedTextImportOptions("NumVariables", 424);
opts.DataLines = [1, Inf];
opts.Delimiter = ",";
opts.EmptyLineRule = "read";
C = readtable("C:\Users\Diyanko\Desktop\NNLS\bin\x64\Release\net5.0\Matrix.csv", opts);
C = table2array(C);
C = str2double(C);

opts = delimitedTextImportOptions("NumVariables", 1);
opts.DataLines = [1, Inf];
opts.Delimiter = ",";
opts.ExtraColumnsRule = "ignore";
opts.EmptyLineRule = "read";
d = readtable("C:\Users\Diyanko\Desktop\NNLS\bin\x64\Release\net5.0\input_Table@400_Ambient@50.csv", opts);
d = table2array(d);
d = str2double(d);

A = []
b = []
Aeq = []
beq = []

opts = delimitedTextImportOptions("NumVariables", 1);
opts.DataLines = [1, Inf];
opts.Delimiter = ",";
opts.ExtraColumnsRule = "ignore";
opts.EmptyLineRule = "read";
lb = readtable("C:\Users\Diyanko\Desktop\NNLS\bin\x64\Release\net5.0\bl", opts);
lb = table2array(lb);
lb = str2double(lb);

opts = delimitedTextImportOptions("NumVariables", 1);
opts.DataLines = [1, Inf];
opts.Delimiter = ",";
opts.ExtraColumnsRule = "ignore";
opts.EmptyLineRule = "read";
ub = readtable("C:\Users\Diyanko\Desktop\NNLS\bin\x64\Release\net5.0\bu", opts);
ub = table2array(ub);
ub = str2double(ub);

x = lsqlin(C,d,A,b,Aeq,beq,lb,ub)
