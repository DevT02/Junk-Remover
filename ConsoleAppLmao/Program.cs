using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using System.Windows.Forms;
namespace Anti_De4dot_remover
{
    // Token: 0x02000002 RID: 2
    internal class Program
    {
        public static int countofths = 0;
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        private static void Main(string[] args)
        {
            Console.Title = "Junk Remover by OFF_LINE";
            Console.ForegroundColor = ConsoleColor.Red;
            string text = args[0];
            try
            {
                Program.module = ModuleDefMD.Load(text);
                Program.asm = Assembly.LoadFrom(text);
                Program.Asmpath = text;
            }
            catch (Exception)
            {
                Console.WriteLine("Not .NET Assembly...");
            }
            string text2 = Path.GetDirectoryName(text);
            bool flag = !text2.EndsWith("\\");
            bool flag2 = flag;
            if (flag2)
            {
                text2 += "\\";
            }
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string sb = @"
     ____.             __     __________                                          
    |    |__ __  ____ |  | __ \______   \ ____   _____   _______  __ ___________  
    |    |  |  \/    \|  |/ /  |       _// __ \ /     \ /  _ \  \/ // __ \_  __ \ 
/\__|    |  |  /   |  \    <   |    |   \  ___/|  Y Y  (  <_> )   /\  ___/|  | \/  
\________|____/|___|  /__|_ \  |____|_  /\___  >__|_|  /\____/ \_/  \___  >__|    
                    \/     \/         \/     \/      \/                 \/                        ";
                Console.WriteLine(sb);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[!] Credit: Prab + illuZion");
                Console.WriteLine("[!] Removing useless nop instructions..");
                Execute(module);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[!] Removed " + removed +  " useless nop instructions!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[!] Removing fake attributes..");
                removeshit();
                removeshit();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Anti-De4dot remover has caught an exception. Original message: " + ex.ToString());
            }
            string text3 = string.Format("{0}{1}_noJunk{2}", text2, Path.GetFileNameWithoutExtension(text), Path.GetExtension(text));
            ModuleWriterOptions moduleWriterOptions = new ModuleWriterOptions(Program.module);
            moduleWriterOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
            moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
            NativeModuleWriterOptions nativeModuleWriterOptions = new NativeModuleWriterOptions(Program.module);
            nativeModuleWriterOptions.MetaDataOptions.Flags |= MetaDataFlags.PreserveAll;
            nativeModuleWriterOptions.Logger = DummyLogger.NoThrowInstance;
            bool isILOnly = Program.module.IsILOnly;
            if (isILOnly)
            {
                Program.module.Write(text3, moduleWriterOptions);
            }
            else
            {
                Program.module.NativeWrite(text3, nativeModuleWriterOptions);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[!] Removed " + countofths + " FakeAttributes/AntiDe4dot cases");
            Console.ReadLine();
        }
        private static IList<TypeDef> lista(ModuleDef A_0)
        {
            return A_0.Types;
        }
        public static void removeshit()
        {
            for (int i = 0; i < Program.module.Types.Count; i++)
            {
                TypeDef typeDef = Program.module.Types[i];
                if (typeDef.HasInterfaces)
                {
                    for (int jic = 0; jic < typeDef.Interfaces.Count; jic++)
                    {
                        if (typeDef.Interfaces[jic].Interface != null)
                        {
                            if (typeDef.Interfaces[jic].Interface.Name.Contains(typeDef.Name) || typeDef.Name.Contains(typeDef.Interfaces[jic].Interface.Name))
                            {
                                Program.module.Types.RemoveAt(i);
                                countofths++;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < module.CustomAttributes.Count; i++)
            {
                CustomAttribute attribute = module.CustomAttributes[i];
                bool flag = attribute == null;
                if (!flag)
                {
                    TypeDef type = attribute.AttributeType.ResolveTypeDef();
                    bool flag2 = type == null;
                    if (!flag2)
                    {

                        bool flag23123321 = type.Name == "ConfusedByAttribute";
                        if (flag23123321)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag2123132123123213 = type.Name == "ZYXDNGuarder";
                        if (flag2123132123123213)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag3 = type.Name == "YanoAttribute";
                        if (flag3)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag4 = type.Name == "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode";
                        if (flag4)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag5 = type.Name == "SmartAssembly.Attributes.PoweredByAttribute";
                        if (flag5)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag6 = type.Name == "SecureTeam.Attributes.ObfuscatedByAgileDotNetAttribute";
                        if (flag6)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag7 = type.Name == "ObfuscatedByGoliath";
                        if (flag7)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag8 = type.Name == "NineRays.Obfuscator.Evaluation";
                        if (flag8)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag9 = type.Name == "EMyPID_8234_";
                        if (flag9)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag10 = type.Name == "DotfuscatorAttribute";
                        if (flag10)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag11 = type.Name == "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute";
                        if (flag11)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag12 = type.Name == "BabelObfuscatorAttribute";
                        if (flag12)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag13 = type.Name == ".NETGuard";
                        if (flag13)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag14 = type.Name == "OrangeHeapAttribute";
                        if (flag14)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag15 = type.Name == "WTF";
                        if (flag15)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag16 = type.Name == "<ObfuscatedByDotNetPatcher>";
                        if (flag16)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool duwggdyq3e6f7yqwsdas = type.Name == "SecureTeam.Attributes.ObfuscatedByCliSecureAttribute";
                        if (duwggdyq3e6f7yqwsdas)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool sajdha8edy7128 = type.Name == "SmartAssembly.Attributes.PoweredByAttribute";
                        if (sajdha8edy7128)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        bool flag1208312983 = type.Name == "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode";
                        if (flag1208312983)
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "OiCuntJollyGoodDayYeHavin_____________________________________________________")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "ProtectedWithCryptoObfuscatorAttribute")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "NetGuard")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "ZYXDNGuarder")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "DotfuscatorAttribute")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                        if (type.Name == "SecureTeam.Attributes.ObfuscatedByAgileDotNetAttribute")
                        {
                            lista(module).Remove(type);
                            module.CustomAttributes.Remove(attribute);
                            countofths++;
                        }
                    }
                }
            }
            foreach (var type in module.Types.ToList().Where(t => t.HasInterfaces))
            {
                for (var i = 0; i < type.Interfaces.Count; i++)
                {
                    if (type.Interfaces[i].Interface.Name.Contains(type.Name) || type.Name.Contains(type.Interfaces[i].Interface.Name))
                    {
                        module.Types.Remove(type);
                        countofths++;
                    }
                }
            }

            List<string> fakeObfuscators = new List<string>()
            {
                "DotNetPatcherObfuscatorAttribute",
                "DotNetPatcherPackerAttribute",
                "DotfuscatorAttribute",
                "ObfuscatedByGoliath",
                "dotNetProtector",
                "PoweredByAttribute",
                "AssemblyInfoAttribute",
                "BabelAttribute",
                "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute",
                "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode",
                "NineRays.Obfuscator.Evaluation",
                "YanoAttribute",
                "SmartAssembly.Attributes.PoweredByAttribute",
                "NetGuard",
                "SecureTeam.Attributes.ObfuscatedByCliSecureAttribute",
                "Reactor",
                "ZYXDNGuarder",
                "CryptoObfuscator",
                "MaxtoCodeAttribute",
                ".NETReactorAttribute",
                "BabelObfuscatorAttribute"
            };
            for (int i = 0; i < module.Types.ToList().Count; i++)
            {
                if (fakeObfuscators.Contains(module.Types[i].Name))
                { 
                     //UInt32 a = module.Types[i].MDToken.Raw;
                     //TypeDef type = module.ResolveTypeDef(MDToken.ToRID(a));
                     module.Types.Remove(module.Types[i]);              
                     countofths++;
                }
            }
        }
        private static bool IsNopBranchTarget(MethodDef method, Instruction nopInstr)
        {
            var instr = method.Body.Instructions;
            for (int i = 0; i < instr.Count; i++)
            {
                if (instr[i].OpCode.OperandType == OperandType.InlineBrTarget || instr[i].OpCode.OperandType == OperandType.ShortInlineBrTarget && instr[i].Operand != null)
                {
                    Instruction instruction2 = (Instruction)instr[i].Operand;
                    if (instruction2 == nopInstr)
                        return true;
                }
            }
            return false;
        }
        public static int removed = 0;
        public static void Execute(ModuleDefMD module)
        {
            foreach (var type in module.Types.Where(t => t.HasMethods))
            {
                foreach (var method in type.Methods.Where(m => m.HasBody && m.Body.HasInstructions))
                {
                    if (method.HasBody)
                    {
                        var instr = method.Body.Instructions;
                        for (int i = 0; i < instr.Count; i++)
                        {
                            if (instr[i].OpCode == OpCodes.Nop &&
                                !IsNopBranchTarget(method, instr[i]) &&
                                !IsNopSwitchTarget(method, instr[i]) &&
                                !IsNopExceptionHandlerTarget(method, instr[i]))
                            {
                                instr.RemoveAt(i);

                                removed++;
                                i--;
                            }
                        }
                    }
                }
            }
        }

        private static bool IsNopSwitchTarget(MethodDef method, Instruction nopInstr)
        {
            var instr = method.Body.Instructions;
            for (int i = 0; i < instr.Count; i++)
            {
                if (instr[i].OpCode.OperandType == OperandType.InlineSwitch && instr[i].Operand != null)
                {
                    Instruction[] source = (Instruction[])instr[i].Operand;
                    if (source.Contains(nopInstr))
                        return true;
                }
            }
            return false;
        }

        private static bool IsNopExceptionHandlerTarget(MethodDef method, Instruction nopInstr)
        {
            bool result;
            if (!method.Body.HasExceptionHandlers)
                result = false;
            else
            {
                var exceptionHandlers = method.Body.ExceptionHandlers;
                foreach (var exceptionHandler in exceptionHandlers)
                {
                    if (exceptionHandler.FilterStart == nopInstr ||
                        exceptionHandler.HandlerEnd == nopInstr ||
                        exceptionHandler.HandlerStart == nopInstr ||
                        exceptionHandler.TryEnd == nopInstr ||
                        exceptionHandler.TryStart == nopInstr)
                        return true;
                }
                result = false;
            }
            return result;
        }

        // Token: 0x04000002 RID: 2
        public static string Asmpath;

        // Token: 0x04000003 RID: 3
        public static ModuleDefMD module;

        // Token: 0x04000004 RID: 4
        public static Assembly asm;

    }
}
