;Marco Balducci 3H 2024-02-19
;Programma che cverifica se n e' primo
name "numero primo"                   
.model small

.data
   N DB 7
   primo DB 1 ;1 se primo, 0 se non primo
   vero DW "Il numero e' primo.$"
   falso DW "Il numero non e' primo.$"
   
.code
.startup
   
   ;se minore di 2 salto tutto il programma
   cmp N, 2
   
   JC ISPRIMO 
   
   ;caso N > 1
   
   mov bl, 1
   
   CONTROLLO: 
   
   inc bl
   mov al, N
   mov ah, 0
   
   div bl            
     
   cmp ah, 0
   
   JNZ CONTROLLO ;se il resto della divisione e' diverso da zero continua
   
   ;a questo punto esce se di = N oppure non e' primo
   
   cmp bl, N
   
   JZ ISPRIMO
   
   mov al, 0
   mov primo, al
   
   ISPRIMO:
   
   ;stampa output
   
   mov ah, 9
   
   cmp al, 0
   
   JZ NONPRIMO
   
   ;il numero e' primo
   lea dx, vero
   int 21h        
   
   jmp FINE
   
   NONPRIMO:
   
   ;il numero non e' primo
   lea dx, falso
   int 21h
   
   FINE: 
   
.exit
END