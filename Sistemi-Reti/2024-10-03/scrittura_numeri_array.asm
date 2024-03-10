;Marco Balducci 3H
;primi 10 numeri naturali in array
name "numeri naturali in array"
.model small

.data
    vett DB 0,0,0,0,0,0,0,0,0,0

.code
.startup
    
    mov di, 0
    mov ax, 0     
    
    AGGIUNTA:
    
        mov vett[di], al
        inc ax
        inc di
        
    cmp di, 10
    JNZ AGGIUNTA
    
    ;output
    
    mov dx, 0
    mov di, 0
    mov ah, 2
    
    STAMPA:
    
        mov dl, vett[di]
        add dl, 48
        int 21h
        
        inc di
        
        mov dl, 0AH
        int 21h
        
        mov dl, 0DH
        int 21h
        
    cmp di, 10
    JNZ STAMPA
                 
    
.exit
END