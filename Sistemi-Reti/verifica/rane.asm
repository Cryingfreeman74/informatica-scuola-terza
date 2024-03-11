;Marco Balducci 3H
name "rane"
.model small

.data
    ;inizializzo tutte le variabili utili
    popIniziale DW 10
    popFinale DW 70
    risultato DW 0
    
.code
.startup
   
   ;sposto in ax il numero corrente della popolazione
   mov ax, popIniziale
   
   PASSAGGIO:       
   
   ;se ax >= obiettivo fine
   cmp ax, popFinale
   JNC FINE
   
   ;raddoppio
   shl ax, 1
   
   ;in di sono contenuti i giorni passati dall'ultimo incidente
   inc di
   
   ;incremento il numero di giorni passati
   inc risultato
   
   ;se arriva il giorno dell'incidente sottraggo
   cmp di, 3
   JNZ PASSAGGIO
   
   ;riazzero i giorni dall'ultimo incidente
   mov di, 0
   
   ;3 im bx serve per dividere
   mov bx, 3
   
   ;salvo il numero di persone prima dell'incidente
   push ax
   
   ;preparo dx per la divisione
   mov dx, 0
   
   ;divido per 3
   div bx
   
   ;il numero delle persone pre-incidente e' ora in bx
   pop bx                                             
   
   ;calcolo il numero dei superstiti sottraendo a bx il terzo e aggiungendo il resto
   sub bx, ax
   add bx, dx ;se questo passaggio di riaggiungere il testo non e' da fare potete toglierlo ;3
   
   ;riporto il risultato in ax
   mov ax, bx
   
   jmp PASSAGGIO
     
   FINE:

.exit
END