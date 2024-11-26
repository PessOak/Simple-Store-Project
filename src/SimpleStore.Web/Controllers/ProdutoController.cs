using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;
using System.Security.Claims;

public class ProdutoController : Controller
{
    private readonly ProdutoService _produtoService;
    private readonly ProdutoCarrinhoService _produtoCarrinhoService;

    public ProdutoController(ProdutoService produtoService, ProdutoCarrinhoService produtoCarrinhoService)
    {
        _produtoService = produtoService;
        _produtoCarrinhoService = produtoCarrinhoService;
    }

    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoService.ListarProdutos();
        return View(produtos);
    }

    public async Task<IActionResult> Details(string nome)
    {
        var produto = await _produtoService.ListarProdutoPeloNome(nome);

        if (produto == null)
        {
            return NotFound();
        }

        //FAZER alteração aqui para redirecionar apenas quando pessoa não logada tentar adicionar o produto, não quando clicar em ver detalhes
        // Recuperar o CPF do usuário logado usando Claims (caso esteja utilizando login baseado em CPF)
        var cpfComp = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(cpfComp))
        {
            // Se o CPF não for encontrado, redirecionar para produtos/home 
            return RedirectToAction("Index", "CadastroCliente");
        }

        return View(produto);
    }
}
