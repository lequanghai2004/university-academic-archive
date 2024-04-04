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
      halt
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
