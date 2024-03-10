;Marco Balducci 3H
;verifica palidromia
name "palindromo"
.model small

.data
    vett DW 5,14,21,28,21,14,5
    palindromo DW "l'array e' palindromo. $"
    nonpalindromo DW "l'array non e' palindromo $"
.code
.startup
   
    mov di, 0
    mov bx, 12
   
    CONTROLLO:
       mov ax, vett[di]
    
       cmp ax, vett[bx]
       JNZ STAMPA
       
       add di, 2
       sub bx, 2
        
    cmp di, bx
    JNZ CONTROLLO
    
    STAMPA:
    
    mov ah, 9
    
    cmp di, bx
    JZ PALINDROMOJMP
    
    ;non e' palindromo
    
    lea dx, nonpalindromo
    int 21h
    
    jmp FINALE
    
    ;e' palindromo
    PALINDROMOJMP:
    
    lea dx, palindromo
    int 21h
        
    FINALE:
.exit
END