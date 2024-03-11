;Marco Balducci 3H
name "fibonacci"
.model small

.data
    ;salvo N, i primi due numero da stampare e lo spazio
    N DW 10
    iniziale DW "1 1 $"
    space equ ' '
    
.code
.startup

   mov bx, 1 ;uso bx per ricordare l'ultimo numero della serie
   mov cx, 1 ;uso bx per ricordare il penultimo numero della serie
   
   ;utilizzo di per tenere conto del numero di numeri da stampare
   mov di, N
   
   ;N > 2
   sub di, 2
   cmp di, 1
   JC FINE
   
   ;stampa 1 1
   lea dx, iniziale
   mov ah, 9
   int 21h
   
   PASSAGGIO:
   
   ;calcolo il prossimo numero della serie      
   mov ax, 0
   add ax, bx
   add ax, cx
   
   push ax ;push del risultato per salvarlo poi in bx (diventa l'ultimo numero della serie)
   push bx ;push di bx per salvarlo poi in cx (diventa il penultimo numero della serie)
   push di ;push di di per poterlo ripristinare in seguito all'output    
   
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
   
   ;se ho finito le cifre fine output numero
   cmp di, 0
   JNZ STAMPA    
   
   ;stampa spazio
   mov dl, space
   mov ah, 2
   int 21h
   
   ;fine output
   
   ;ripristino di
   pop di
   
   ;sposto l'ultimo valore della serie in cx e l'ultimo risultato in bx
   pop cx
   pop bx
   
   ;decremento il numero dei numeri rimasti nella serie         
   dec di
   
   ;controllo se sono arrivato al numero richiesto di numeri della serie di fibonacci
   cmp di, 0
   JNZ PASSAGGIO
 
   FINE:

.exit
END