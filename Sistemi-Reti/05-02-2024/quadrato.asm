;Marco Balducci 3H 05-02-2024
;Calcolo del quadrato di N mediante la somma dei primi n numeri dispari
name "esercizio quadrato"

.model small

.data

    num dw 5
    result dw ?

.code
.startup
    
    ;inizializzazione registri
    mov di, num
    mov ax, 0
    mov bx, 1
    
    ;aggiunta di valori al quadrato
    
    SOMMA:
    
    add ax, bx
    add bx, 2
    dec di      ;decremento contatore
    
    CMP di, 0
    JNZ SOMMA
    
    mov result, ax
   
.exit
END