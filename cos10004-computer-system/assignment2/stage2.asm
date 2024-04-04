getBreakerName:
      mov r4, #getBreakerNameMss
      mov r5, #breakerName
      str r4, .WriteString
      str r5, .ReadString
getMakerName:
      mov r4, #getMakerNameMss
      mov r6, #makerName
      str r4, .WriteString
      str r6, .ReadString
getMaxQueries:
      mov r4, #getMaxQueriesMss
      mov r7, #maxGuessAllowed
      str r4, .WriteString
      ldr r7, .InputNum
printInfo:
      mov r8, #newlinechar
      str r8, .WriteString
printBreakerName:
      mov r4, #breakerNameNoti
      str r4, .WriteString
      str r5, .WriteString 
      str r8, .WriteString
printMakerName:
      mov r4, #makerNameNoti
      str r4, .WriteString
      str r6, .WriteString 
      str r8, .WriteString
printMaxGuessAllowed:
      mov r4, #maxQueriesNoti
      str r4, .WriteString 
      str r7, .WriteUnsignedNum
      str r8, .WriteString
stage2: 
      push {r0}
      mov r0, #code
      bl getcode
      pop {r0}
      halt
getcode:
      push {r4, r5, r6}
      mov r4, #getCodeMss
      mov r5, r0
      b input
reEnter:
      mov r4, #reEnterMss
      str r4, .WriteString
input:
      mov r6, #0
      str r4, .WriteString
      str r5, .ReadString
validate:
      ldrb r4, [r5 + r6]
      cmp r4, #0x72     ; red
      beq continue
      cmp r4, #0x67     ; green
      beq continue
      cmp r4, #0x62     ; blue
      beq continue 
      cmp r4, #0x79     ; yellow
      beq continue 
      cmp r4, #0x70     ; purple
      beq continue
      cmp r4, #0x63     ; cyan
      beq continue
      b reEnter
continue:
      add r6, r6, #1
      cmp r6, #4
      blt validate
      ldrb r4, [r5 + r6]
      cmp r4, #0
      bne reEnter
      pop {r4, r5, r6}
      ret
newlinechar: .ASCIZ "\n"
getMakerNameMss: .ASCIZ "Enter code maker name: \n"
getBreakerNameMss: .ASCIZ "Enter code breaker name: \n"
getMaxQueriesMss: .ASCIZ "Enter maximum number of queries allowed: \n"
breakerNameNoti: .ASCIZ "Codebreaker is "
makerNameNoti: .ASCIZ "Codemaker is "
maxQueriesNoti: .ASCIZ "Maximum number of guesses: "
makerName: .BLOCK 64
breakerName: .BLOCK 64
maxGuessAllowed: .BYTE 0
getCodeMss: .ASCIZ "Enter the code: \n"
reEnterMss: .ASCIZ "\nInvalid code! Enter again \n"
code: .BYTE 0
      0
      0
      0
      0
