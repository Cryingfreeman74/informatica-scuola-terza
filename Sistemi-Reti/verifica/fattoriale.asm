;Marco Balducci 3H
name "fattoriale"
.model small

.data
    numero DW 5 ;numero di cui calcolare il fattoriale

.code
.startup

   mov ax, numero ;salvo numero in ax
   
   ;salvo in di numero -1
   mov di, ax
   dec di
   
   PASSAGGIO:
   
   mul di ;se non e' zero moltiplico
   dec di ;decremento di fino ad arrivare a 0, a quel punto non moltiplico piu' ax per di
   
   cmp di, 0 ;quando arrivo a 0 fine
   JNZ PASSAGGIO
   
   ;output
   
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