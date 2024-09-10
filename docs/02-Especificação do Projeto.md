# Especificações do Projeto

## Personas

### Persona 1
![image](https://github.com/user-attachments/assets/e906c522-4813-47be-8773-a66ef00dd3c6)

### Persona 2
![image](https://github.com/user-attachments/assets/903df5ee-e64b-4e18-bf18-8936348eb27b)

### Persona 3
![image](https://github.com/user-attachments/assets/f333ed74-fd8c-4b7c-a64e-b6671b522087)

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Adriano Ramos | Uma loja virtual que seja mais simples e intuitiva           | Comprar online sem muita burocracia                |
| Adriano Ramos | Comprar online podendo comprar os preços do mercado          | Pagar o menor preço |
| Neuza Andrade | Comprar ítens para o dia a dia de forma prática              | Conseguir comprar online |
|              |                       |               |
|              |                       |               |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF_01| O sistema deve permitir o cadastro de compradores, com informações como nome, e-mail, telefone, e endereço para entrega. | ALTA | 
|RF-02| O sistema deve permitir o cadastro de vendedores, incluindo informações do negócio como nome, localização (cidade/bairro), horário de funcionamento, e WhatsApp Business para contato.    | ALTA |
|RF-03| O sistema deve permitir que os vendedores adicionem, editem e removam produtos, incluindo detalhes como nome, descrição, preço, imagens e estoque disponível.  | ALTA |
|RF-04| O sistema deve ter um filtro de pesquisa de produtos para o comprador.  | ALTA |
|RF-05| O sistema deve permitir que os compradores adicionem produtos ao carrinho de compras e visualizem o total da compra.  | ALTA |
|RF-06| O sistema deve permitir que os compradores realizem pagamentos seguros diretamente na plataforma, utilizando métodos de pagamento online como cartão de crédito/débito e Pix após adição ao carrinho. (simulação)  | ALTA |
|RF-07| Após a conclusão da compra, o sistema deve fornecer um botão/link "Combinar Entrega" que redireciona o comprador ao WhatsApp Business do vendedor para combinar a entrega ou retirada do produto.  | ALTA |
|RF-08| O sistema deve fornecer aos vendedores relatórios simplificados de vendas, incluindo informações sobre produtos mais vendidos, faturamento, e estoque, para ajudar na gestão de seu negócio.  | ALTA |
|RF-09| A plataforma deve permitir que os administradores gerenciem vendedores e compradores, incluindo a aprovação de novos cadastros, moderação de avaliações, e gerenciamento de conteúdo. | ALTA |
|RF-10| A plataforma deve ter um painel administrativo que permita a monitoração das transações realizadas, verificação de pagamentos, e resolução de disputas, caso necessário.   | MÉDIA |
|RF-11| A plataforma deve oferecer suporte ao cliente, incluindo FAQs e comunicação por e-mail.   | MÉDIA |
|RF-12| O sistema deve permitir que os compradores avaliem produtos e vendedores após a compra, ajudando a criar uma comunidade confiável e transparente. | BAIXA |


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF_01| A página principal do site deve carregar em até 5 segundos em uma conexão de internet padrão  | ALTA | 
|RNF-02| As principais ações do usuário (como adicionar um produto ao carrinho) devem ser processadas em até 3 segundos.  | ALTA | 
|RNF-03| O site deve ser acessível e funcional em dispositivos móveis e desktops. | ALTA | 
|RNF-04| O site deve ser compatível com os navegadores mais comuns, como Chrome, Firefox e Edge.  | ALTA | 
|RNF-05| O site deve conter um sistema de login e senha para proteger áreas restritas.  | ALTA |
|RNF-06| O site deve ter uma interface intuitiva e simples de se usar, fazendo jus ao seu nome.  | MÉDIA |
|RNF-07| O código deve ser bem-organizado para facilitar a compreensão e manutenção de outros desenvolvedores.  | MÉDIA |
|RNF-08| O sistema deve ser projetado de forma a permitir a adição de novas funcionalidades com mudanças mínimas no código existente. | BAIXA |


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |



## Diagrama de Casos de Uso

![image](https://github.com/user-attachments/assets/d4fd166d-cb80-42ec-a31d-4c1080af3132)
