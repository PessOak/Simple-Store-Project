# Especificações do Projeto

## Personas

### Persona 1
![image](https://github.com/user-attachments/assets/e906c522-4813-47be-8773-a66ef00dd3c6)

### Persona 2
![image](https://github.com/user-attachments/assets/903df5ee-e64b-4e18-bf18-8936348eb27b)

### Persona 3
![image](https://github.com/user-attachments/assets/f333ed74-fd8c-4b7c-a64e-b6671b522087)

### Persona 4
Ana Costa 

Biografia: Ana Costa, 23 anos, é uma jovem empreendedora que vende artesanato e acessórios personalizados em um carrinho móvel. Recentemente formada em Design Gráfico, Ana decidiu seguir sua paixão por artesanato e montar seu próprio negócio. Ela opera principalmente em eventos locais e feiras de rua. 

Objetivo: Ana quer expandir seu alcance e aumentar as vendas oferecendo seus produtos também online. Ela busca uma forma de gerenciar seu estoque e finanças de maneira mais eficiente, além de oferecer aos clientes a opção de comprar seus produtos através de uma loja virtual. 

Frustração: Ana enfrenta dificuldades em gerenciar seu inventário manualmente e tem pouco tempo para acompanhar as finanças devido à natureza dinâmica do seu trabalho. Ela também sente que perde vendas porque não tem uma presença online consistente e não consegue processar pedidos de forma eficiente. 

Necessidade Específica: 

Uma plataforma de e-commerce fácil de configurar, ideal para alguém com conhecimentos básicos de tecnologia. 

Funcionalidades de gerenciamento de estoque que ajudem a manter o controle entre as vendas físicas e online. 

Integração com sistemas de pagamento digital para facilitar transações e ampliar as opções de pagamento para seus clientes. 

Ferramentas de marketing simples para promover a loja e atrair mais clientes para sua loja virtual e eventos. 

### Persona 5
Rafael Almeida 


Biografia: Rafael Almeida, 28 anos, é o proprietário de uma pequena loja de moda masculina em um bairro moderno. Formado em Administração de Empresas, Rafael sempre teve o sonho de empreender e, com o tempo, abriu sua própria loja. Ele está sempre em busca de maneiras inovadoras de crescer e modernizar seu negócio. 

Objetivo: Rafael quer criar uma loja virtual para complementar sua loja física e alcançar um público mais amplo. Ele deseja integrar suas operações online e offline para otimizar o gerenciamento de estoque e melhorar o atendimento ao cliente. 

Frustração: Embora Rafael tenha boas habilidades administrativas, ele encontra dificuldades em gerenciar simultaneamente as vendas físicas e online. Ele também sente que a falta de dados detalhados sobre as vendas e o comportamento dos clientes limita sua capacidade de planejar estratégias eficazes de marketing. 

Necessidade Específica: 

Uma plataforma de e-commerce intuitiva que permita fácil integração com o sistema de vendas da loja física. 

Ferramentas de análise detalhada para entender melhor o comportamento dos clientes e o desempenho das vendas. 

Recursos de automação para gerenciar o estoque e as promoções, economizando tempo e reduzindo erros. 

Opções de personalização da loja online para criar uma experiência de compra que reflita o estilo e a identidade da loja física. 



## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Adriano Ramos | Uma loja virtual que seja mais simples e intuitiva           | Comprar online sem muita burocracia                |
| Adriano Ramos | Comprar online podendo comprar os preços do mercado          | Pagar o menor preço |
| Neuza Andrade | Comprar ítens para o dia a dia de forma prática              | Conseguir comprar online |
| José Antônio  | Anunciar meus produtos online                                | Aumentar minhas vendas              |
| Claudio Machado | Abrir mais um canal de vendas dos meus produtos            | Não depender das vendas no balcão de loja          |

Apresente aqui as histórias de usuário que são relevantes para o projeto de sua solução. As Histórias de Usuário consistem em uma ferramenta poderosa para a compreensão e elicitação dos requisitos funcionais e não funcionais da sua aplicação. Se possível, agrupe as histórias de usuário por contexto, para facilitar consultas recorrentes à essa parte do documento.


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF_01| O sistema deve permitir o cadastro de compradores, com informações como nome, e-mail, telefone, e endereço para entrega. | ALTA | 
|RF-02| O sistema deve permitir o cadastro de fornecedores, incluindo informações do negócio como nome, localização (cidade/bairro), horário de funcionamento, e WhatsApp Business para contato.    | ALTA |
|RF-03| O sistema deve permitir que os fornecedores adicionem, editem e removam produtos, incluindo detalhes como nome, descrição, preço, imagens e estoque disponível.  | ALTA |
|RF-04| O sistema deve ter um filtro de pesquisa de produtos para o comprador.  | ALTA |
|RF-05| O sistema deve permitir que os compradores adicionem produtos ao carrinho de compras e visualizem o total da compra.  | ALTA |
|RF-06| Após a conclusão da compra, o sistema deve fornecer um botão/link "Combinar Entrega" que redireciona o comprador ao WhatsApp Business do vendedor para combinar o pagamento e a entrega ou retirada do produto.  | ALTA |
|RF-07| O sistema deve enviar aos fornecedores relatórios simplificados de vendas, incluindo informações sobre produtos mais vendidos, faturamento, e estoque, para ajudar na gestão de seu negócio.  | ALTA |
|RF-08| A plataforma deve permitir que os administradores gerenciem compradores e compradores, incluindo a aprovação de novos cadastros, moderação de avaliações, e gerenciamento de conteúdo. | ALTA |
|RF-09| A plataforma deve ter um painel administrativo que permita a monitoração das transações realizadas e resolução de disputas, quando necessário.   | MÉDIA |
|RF-10| A plataforma deve oferecer suporte ao cliente, incluindo FAQs e comunicação por e-mail.   | MÉDIA |
|RF-11| O sistema deve permitir que os compradores avaliem produtos e fornecedores após a compra, ajudando a criar uma comunidade confiável e transparente. | BAIXA |


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
|01| O projeto precisa ser apresentado até o término do semestre. |
|02| Não pode ser desenvolvido um módulo de backend        |
|03|O site deve aderir estritamente às normas éticas da instituição, proibindo a publicação de conteúdos ofensivos, discriminatórios ou que infrinjam os códigos de conduta.  |
|04|O conteúdo do projeto será armazenado em um repositório na plataforma GitHub.  |
|05|A implementação do backend deve ser feita usando C#.  |
|06|É necessário usar um banco de dados relacional, como PostgreSQL ou MySQL, para implementar pelo menos três CRUD's .  |
|07|A equipe precisa trabalhar em conjunto em todas as fases do projeto, garantindo que todos os integrantes participem ativamente e ativamente no desenvolvimento das atividades.  |
|08|O desenvolvimento do front-end deve utilizar tecnologias web convencionais, tais como HTML, CSS, JavaScript e Bootstrap. |




## Diagrama de Casos de Uso

![image](https://github.com/user-attachments/assets/d4fd166d-cb80-42ec-a31d-4c1080af3132)
