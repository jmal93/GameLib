Esse é um projeto de uma biblioteca de jogos onde o usuário pode adicionar jogos a sua biblioteca pessoal em uma coleção de jogos disponíveis. Ele é feito com a seguinte stack:
- Next.js para o frontend
- ASP.NET Core para o backend
- Database em uma imagem docker de SQL Server

# Instalação
Para testar na sua máquina, basta clonar o repositório, entrar no diretório onde foi clonado e digitar o seguinte comando:
```
docker-compose up --build
```

Esse comando irá instalar as imagens necessárias para o funcionamento do projeto.

> [!NOTE]  
> Ao instalar pela primeira vez, pode ocorrer um erro durante a instalação da imagem ASP.NET Core. Ao tentar instalar novamente, deve instalar tudo normalmente.

Depois de tudo ser devidamente instalado, você pode acessar através da url: http://localhost:3000/login
