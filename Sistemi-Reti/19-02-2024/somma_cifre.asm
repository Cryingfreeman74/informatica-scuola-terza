;Marco Balducci 3H 19-02-2024
;Somma cifre di un numero

name "somma cifre"
.model small

.stack

.data
    
    stringa DW 'risultato : $'
    N DB 129

.code
.startup
    ;calcolo somma cifre
    
    mov al, N
    mov bl, 100
    
    ;aggiungo centinaia
    div bl    
    
    add bh, al
    mov al, ah
    mov ah, 0
    
    ;aggiungo decine
    mov bl, 10
    div bl     
    
    add bh, al
    
    ;aggiungo unita'
    add bh, ah 
    
    ;stampa output
    ;stampa scritta risultato:
    mov ah, 9
    lea dx, stringa
    
    int 21h
    mov ah, 0
    
    ;stampa decine
    
    mov al, bh
    mov bx, 10 ;sposto 10 in bx per utilizzarlo nella divisione delle cifre, uso 10 perche' non avro' mai centinaia o +
    
    div bl
    mov bh, ah
    
    mov ah, 2
    
    cmp al, 0 ;se ho 0 come valore per le diecine allora salto
    
    JZ UNITA
    
    mov dl, al
    add dl, 48
    
    int 21h
    
    ;stampa unita'
    UNITA:
    mov dl, bh
    add dl, 48
    
    int 21h
    
    
.exit
END