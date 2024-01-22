;Balducci Marco 3H

name 'esercizio 2'
    
.MODEL small
    
.data ;dichiarazione ed inizializzazione delle variabili

    X DW 100
    Y DW 45
    Z DW 15
    W DW ?  
    
.code
    .startup ;equazione: W = X -2Y + 3Z
    
        MOV AX, X ;utilizzo ax come registro di appoggio nei calcoli
        SUB AX, Y 
        SUB AX, Y
        ADD AX, Z
        ADD AX, Z
        ADD AX, Z
        MOV W, AX  
        INT 20h      
        
    .exit
end