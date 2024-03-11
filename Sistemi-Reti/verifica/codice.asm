;Marco Balducci 3H
name "codice"
.model small

.data
    ;inizializzo le variabili
    a DW ?
    b DW ?
    somma DW ?
    
.code
.startup
   
   ;int a = 5
   mov a, 5  
   
   ;int b = 4
   mov b, 4
   
   ;int somma = a+b
   
   add ax, a
   add ax, b
   mov somma, ax
   
   ;inizializzo dx per stampare
   mov dx, 0
   
   ;if (somma > 10)
   cmp ax, 10
   JA MAIUSCOLO
        
        ;Console.WriteLine('m')
        ;stampa carattere
        mov ah, 2
        mov dl, 'm'
        int 21h
        
        ;stampa a capo
        mov dl, 0AH
        int 21h
        
        mov dl, 0DH
        int 21h 
        
        jmp FINE
   
   ;else
   MAIUSCOLO:
   
        ;Console.WriteLine('M')
        ;stampa carattere
        mov ah, 2
        mov dl, 'M'
        int 21h
        
        ;stampa a capo
        mov dl, 0AH
        int 21h
        
        mov dl, 0DH
        int 21h 
   
   FINE:


.exit
END