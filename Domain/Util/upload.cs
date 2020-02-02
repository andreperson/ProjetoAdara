using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Domain.Util;

namespace Domain.Util
{
    public class Upload
    {
        public static Imagem ImagemUpload(System.Web.HttpPostedFileBase arquivo, string pasta)
        {
            Imagem ImgRet = new Imagem();
            ImgRet.Ok = false;
            ImgRet.Mensagem = string.Empty;
            String NewDir = string.Empty;

            NewDir = Domain.Util.config.PathUpImg + "\\" + pasta + "\\"; 

            if (!string.IsNullOrEmpty(arquivo.ToString()) && arquivo.ContentLength > 0)
            {
                // BLOQUEIA A TRANSFERÊNCIA DE ARQUIVOS MAIOR QUE 1MB
                if (arquivo.ContentLength < (1048576 / 2))
                {
                    String fileExtension = System.IO.Path.GetExtension(arquivo.FileName);
                    String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            ImgRet.Ok = true;
                        }
                    }

                    if (ImgRet.Ok)
                    {
                        try
                        {
                            //Verificando se um diretório existe, retorna uma variavel BOOL (true/false):
                            //String Path = Directory.GetCurrentDirectory();
                            Boolean bExistDirectory = Directory.Exists(NewDir);
                            if (!bExistDirectory)
                            {
                                Directory.CreateDirectory(NewDir);
                            }
                            //salva
                            arquivo.SaveAs(NewDir + arquivo.FileName);
                        }
                        catch (Exception ex)
                        {
                            // MENSAGEM INFORMATIVA PARA O USUÁRIO
                            ImgRet.Ok = false;
                            ImgRet.Mensagem = ex.Message;
                        }
                    }
                    else
                    {
                        // MENSAGEM INFORMATIVA PARA O USUÁRIO
                        ImgRet.Ok = false;
                        ImgRet.Mensagem = "ArquivoInvalido";
                    }

                }
                else
                {
                    // MENSAGEM INFORMATIVA PARA O USUÁRIO
                    ImgRet.Ok = false;
                    ImgRet.Mensagem = "TamanhoMaximo500kb";
                }

            }

            return ImgRet;
        }


        public static Imagem ArquivoUpload(System.Web.HttpPostedFileBase arquivo, string pasta)
        {
            Imagem ImgRet = new Imagem();
            ImgRet.Ok = false;
            ImgRet.Mensagem = string.Empty;
            String NewDir = string.Empty;

            NewDir = Domain.Util.config.PathUpImg + pasta + "\\";

            if (!string.IsNullOrEmpty(arquivo.ToString()) && arquivo.ContentLength > 0)
            {
                // BLOQUEIA A TRANSFERÊNCIA DE ARQUIVOS MAIOR QUE 1MB
                if (arquivo.ContentLength < (1048576 / 2))
                {
                    String fileExtension = System.IO.Path.GetExtension(arquivo.FileName);
                    String[] allowedExtensions = { ".doc", ".pdf", ".docx" };

                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            ImgRet.Ok = true;
                        }
                    }

                    if (ImgRet.Ok)
                    {
                        try
                        {
                            //Verificando se um diretório existe, retorna uma variavel BOOL (true/false):
                            //String Path = Directory.GetCurrentDirectory();
                            Boolean bExistDirectory = Directory.Exists(NewDir);
                            if (!bExistDirectory)
                            {
                                Directory.CreateDirectory(NewDir);
                            }
                            //salva
                            arquivo.SaveAs(NewDir + arquivo.FileName);
                        }
                        catch (Exception ex)
                        {
                            // MENSAGEM INFORMATIVA PARA O USUÁRIO
                            ImgRet.Ok = false;
                            ImgRet.Mensagem = ex.Message;
                        }
                    }
                    else
                    {
                        // MENSAGEM INFORMATIVA PARA O USUÁRIO
                        ImgRet.Ok = false;
                        ImgRet.Mensagem = "ArquivoInvalido";
                    }

                }
                else
                {
                    // MENSAGEM INFORMATIVA PARA O USUÁRIO
                    ImgRet.Ok = false;
                    ImgRet.Mensagem = "TamanhoMaximo500kb";
                }

            }

            return ImgRet;
        }

    }

    //objeto de retorno
    public class Imagem
    {
        public string Mensagem { get; set; }
        public Boolean Ok { get; set; }

    }

}
