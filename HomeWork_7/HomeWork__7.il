
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly HomeWork_7
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 0A 48 6F 6D 65 57 6F 72 6B 5F 37 00 00 )    // ...HomeWork_7..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 0A 48 6F 6D 65 57 6F 72 6B 5F 37 00 00 )    // ...HomeWork_7..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 32 00 00 )                            //  2022..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 62 61 62 37 66 61 65 65 2D 36 39 36 64   // ..$bab7faee-696d
                                                                                                  2D 34 37 63 30 2D 62 33 62 34 2D 61 39 31 37 61   // -47c0-b3b4-a917a
                                                                                                  33 32 65 39 36 31 64 00 00 )                      // 32e961d..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 2E 32 01   // ,Version=v4.7.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 37 2E 32 )          // amework 4.7.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module HomeWork_7.exe
// MVID: {02AAFAFE-F342-4601-8186-0A32DB7FD538}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x068D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit HomeWork_7.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       54 (0x36)
    .maxstack  2
    .locals init ([0] string secret,
             [1] bool V_1)
    IL_0000:  nop
    IL_0001:  ldstr      bytearray (12 04 32 04 35 04 34 04 38 04 42 04 35 04 20 00   // ..2.5.4.8.B.5. .
                                    3F 04 30 04 40 04 3E 04 3B 04 4C 04 3A 00 20 00 ) // ?.0.@.>.;.L.:. .
    IL_0006:  call       void [mscorlib]System.Console::Write(string)
    IL_000b:  nop
    IL_000c:  ldstr      bytearray (1F 04 30 04 40 04 3E 04 3B 04 4C 04 )             // ..0.@.>.;.L.
    IL_0011:  stloc.0
    IL_0012:  call       string [mscorlib]System.Console::ReadLine()
    IL_0017:  ldloc.0
    IL_0018:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_001d:  stloc.1
    IL_001e:  ldloc.1
    IL_001f:  brtrue.s  IL_002e

    IL_0021:  nop
    IL_0022:  ldstr      bytearray (14 04 3E 04 41 04 42 04 43 04 3F 04 20 00 40 04   // ..>.A.B.C.?. .@.
                                    30 04 37 04 40 04 35 04 48 04 35 04 3D 04 2E 00 ) // 0.7.@.5.H.5.=...
    IL_0027:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_002c:  nop
    IL_002d:  nop
    IL_002e:  ldc.i4.1
    IL_002f:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey(bool)
    IL_0034:  pop
    IL_0035:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class HomeWork_7.Program


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 E:\YandexDisk-a.wlas-off\GB\SolutionHomeWork\HomeWork_7\HomeWork__7.res
