public enum Animo
{
    CONCENTRADA = 0,
    POUCO_CONCENTRADA = 1,
    NORMAL = 2,
    DISTRAIDA = 3,
    ENTEDIADA = 4,
    BAGUNCANDO = 5,
    SAINDO = 6
};

public enum VariacaoAnimo
{
    NENHUM,
    POUCO,
    MEDIO,
    BASTANTE,
    ALEATORIO
};

public enum Localizacao
{
    MUITO_FRENTE,
    FRENTE,
    MEIO,
    TRAS,
    MUITO_ATRAS
};

public enum Tipo
{
    SENTADO,
    EM_PE
};


/// <summary>
/// Enumerador usado para facilitar classificação de quantidade de pessoas na plateia
/// </summary>
public enum QuantidadePlateia{
    VAZIO,          // valor de 0.0
    QUASE_VAZIO,    // valor de 0.15
    MUITO_POUCO,    // valor de 0.25
    POUCO,          // valor de 0.4
    MEDIO,          // valor de 0.5
    BASTANTE,       // valor de 0.7
    QUASE_LOTADO,   // valor de 0.85
    LOTADO          // valor de 1
};