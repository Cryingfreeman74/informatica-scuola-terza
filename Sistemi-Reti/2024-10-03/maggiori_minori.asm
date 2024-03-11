;Marco Balducci 3H
;conteggio valori maggiori e minori
name "valori maggiori e minori"
.model small

.data
    vett DW 14, 156, 72, 35, 67
    N DW 50
    maggiori DB 0
    minori DB 0
    
    stringa1 DW "numeri minori: $"
    stringa2 DW "numeri maggiori: $"
    
.code
.startup

    mov ax, N
    mov di, 0
    
    CONTROLLO:
    
    cmp ax, vett[di]
    JC MAGGIORE
    
    inc minori
    dec maggiori
    
    MAGGIORE:
    inc maggiori
    
    add di, 2    
    
    cmp di, 10
    JNZ CONTROLLO
    
    ;output
    
    lea dx, stringa1
    mov ah, 9
    int 21h
    
    mov dl, minori
    add dl, 48
    mov ah, 2
    int 21h
    
    mov dl, 0AH
    int 21h
    
    mov dl, 0DH
    int 21h
    
    lea dx, stringa2
    mov ah, 9
    int 21h
    
    mov dl, maggiori
    add dl, 48
    mov ah, 2
    int 21h    
.exit
END