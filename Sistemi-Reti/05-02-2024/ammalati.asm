;Marco Balducci 3H 05-02-2024
;calcolo tempo per esaurimento quantita' data percentuale

name "esercizio ammalati"

.model small

.data

    ammalati db 200
    percentuale_ammalati db 10
    giorni db ?
    
.code
.startup
    
    ;calcolo quantita' percentuale
    mov al, 100
    mov bl, percentuale_ammalati
    div bl
    mov bl, al
    
    mov al, ammalati
    
    GUARIGIONE:
    
    inc bh
    
    ;calcolo nuovi guariti    
    div bl
    
    ;calcolo ammalati rimasti
    sub ammalati, al
    mov al, ammalati
    
    
    mov ah, 0
    CMP al, 100
    
    JA GUARIGIONE
    
    mov giorni, bh
    
.exit
END 