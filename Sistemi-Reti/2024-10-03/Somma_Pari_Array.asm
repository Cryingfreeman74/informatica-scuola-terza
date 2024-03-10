;Marco Balducci 3H
;conteggio numeri pari in array
name "conteggio pari in array"
.model small
.data
    vett DW 3, 10, 11, 54, 24
    count DW 0
    stringa DW "Numeri pari nell'array: $"
    
.code
.startup    

   mov di, 0
   mov bx, 2
   
   CONTROLLO:
   
   mov ax, vett[di]
   mov dx, 0
   div bx
   
   cmp dx, 0
   JNZ SKIP
     
     add count, 1
   
   SKIP:
   
   add di, 2
   cmp di, 10
   JNZ CONTROLLO
   
   ;output
   ;stringa
   
   lea dx, stringa
   mov ah, 9
   
   int 21h
   
   
   ;numero
   
   mov ax, count
   
   mov di, 0
   mov bx, 10
   mov dx, 0
  
   CIFRA:
      
   div bx
   
   push dx
   mov dx, 0
   inc di
   
   cmp ax, 0
   
   JNZ CIFRA     
           
   mov ah,2
   
   STAMPA:
    
   pop dx
   add dx, 48
   
   dec di
   
   int 21h
   
   cmp di, 0
   
   JNZ STAMPA
   
   

.exit
END