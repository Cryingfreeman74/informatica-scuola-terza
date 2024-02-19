;Marco Balducci 3H 19-02-2024
;somma di tutti i numeri compresi fra A e B

name "somma numeri compresi"
.model small                

.data
   
   stringa DW 'Somma dei valori compresi: $'
   A DW 5
   B DW 10

.code
.startup

   mov ax, A
   mov bx, B
   
   cmp ax, bx
   
   JNC MINORE ;se A <= B allora non sposto nulla
   
   ;altrimenti inverto i registri
   mov ax, B
   mov bx, A
   
   MINORE:
   
   ;a questo punto il valore maggiore si trova in ax
   
   sub ax, bx
   
   mov di, ax ;numero di valori compresi
   inc di     ;aumento di 1 il contatore per includere gli estremi
   
   mov ax, 0 
   
   SOMMA:
   
   add ax, bx
   inc bx
   dec di
   
   cmp di, 0
   
   JNZ SOMMA:
   
   ;output non ancora finito :)
   mov di, 5
   mov cx, 10
   push ax ;somma e' nello stack
   mov ax, 1
   
   CIFRE:    
   
   mul cx
   dec di
   
   mov bx, ax
   pop ax
   div bx
   
   
   cmp di, 0
   JNZ CIFRE       
   
.exit
END