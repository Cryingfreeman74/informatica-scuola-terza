;Marco balducci 3H
name "array"
.model small

.data
    array DW 10, 20, 30, 50, 40, 100, 70, 60, 90, 80
    
.code
.startup

   PASSAGGIO:
   
   ;controllo se sono arrivato alla fine dell'array
   cmp di, 20
   JZ FINE
   
   mov ax, array[di] ;carico in ax ogni valore di array
   add di, 2 ;aumento di di 2 per puntare al prossimo dw
   
   ;in bx e' contenuto il valore massimo
   ;se trovo un numero + grande di bx, lo scambio
   cmp ax, bx
   JC PASSAGGIO
   
   ;scambio
   mov bx, ax
   jmp PASSAGGIO 
   
   FINE:
   
   ;output
   mov ax, bx ;sposto il risultato in ax
   
   ;inizializzo i registri
   mov di, 0
   mov bx, 10
   mov dx, 0
   
   CIFRA:
   
   ;ottengo la cifra + a destra
   div bx
   
   ;salvo la cifra
   push dx
   
   ;azzero dx e incremento il numero delle cifre (di)
   mov dx, 0
   inc di
   
   ;se il risultato della divisione e' zero ho finito le cifre e percio' procedo a stamparle
   cmp ax, 0
   JNZ CIFRA
   
   ;metto in ah il codice per stampare
   mov ah, 2
   
   STAMPA:
   
   ;riprendo la cifra + a sinistra e la rendo il numero effettivo aggiungendo 48
   pop dx
   add dx, 48
   
   ;diminuisco il numero delle cifre rimaste
   dec di
   
   int 21h
   
   ;se ho finito le cifre fine
   cmp di, 0
   JNZ STAMPA
   
.exit
END