# Simulador de Memória
Projeto Simulador de Memória em linguagem C# desenvolvido para a disciplina de Arquitetura e Organização de Computadores 2021. Bacharelado em Tecnologia da Informação. Faculdade COTEMIG.

# Descrição
Este trabalho tem como objetivo possibilitar aos alunos adquirirem experiência prática no desenvolvimento de programas em uma linguagem de programação de alto nível e aprofundar os estudos do funcionamento de uma técnica de mapeamento de memória cache.

# Problema
O trabalho consiste em simular o funcionamento da troca de blocos entre uma memória principal e uma memória cache, utilizando a técnica associativa por conjunto de N posições.

# Requerimentos
- Funcionamento do Simulador:

        1- O simulador deverá receber como entrada os seguintes dados:
          - O tamanho da memória principal em bytes.
          - O tamanho do bloco em bytes.
          - A quantidade de linhas da memória cache.
          - O valor de N.
          - O algoritmo de substituição que será utilizado pela memória cache (LRU, LFU, FIFO).
          - A sequência de números de blocos que serão acessados pelo processador durante a execução do programa.

        2- A memória cache deverá estar inicialmente vazia.
        
        3- O simulador deverá disponibilizar um botão para a carga de bloco passo a passo, a partir da
           memória principal, para a memória cache.

        4- O simulador deverá conter, no mínimo, uma interface para:
          - Entrada dos dados listados no item 1.
          - Visualização dos blocos na memória principal.
          - Visualização dos blocos carregados na memória cache, passo a passo.
          - Visualização da troca de blocos entre as memórias, utilizando o algoritmo
            de substituição previamente selecionado.
