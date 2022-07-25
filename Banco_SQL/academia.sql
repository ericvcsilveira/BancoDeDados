-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3307
-- Tempo de geração: 25-Jul-2022 às 00:28
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `academia`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `alunos`
--

CREATE TABLE `alunos` (
  `matricula` int(11) NOT NULL,
  `pontos` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `cpf` bigint(11) NOT NULL,
  `datanasc` date NOT NULL,
  `data_cadastro` date NOT NULL,
  `email` varchar(40) NOT NULL,
  `celular` varchar(20) NOT NULL,
  `sexo` varchar(15) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numero` int(11) NOT NULL,
  `bairro` varchar(30) NOT NULL,
  `cidade` varchar(50) NOT NULL,
  `estado` varchar(30) NOT NULL,
  `codigo_unidade` int(11) NOT NULL,
  `data_contratacao` date DEFAULT NULL,
  `id_plano` int(11) DEFAULT NULL,
  `codigo_professor` int(11) DEFAULT NULL,
  `preco` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `alunos`
--

INSERT INTO `alunos` (`matricula`, `pontos`, `nome`, `cpf`, `datanasc`, `data_cadastro`, `email`, `celular`, `sexo`, `cep`, `rua`, `numero`, `bairro`, `cidade`, `estado`, `codigo_unidade`, `data_contratacao`, `id_plano`, `codigo_professor`, `preco`) VALUES
(6, 10, 'Eric Carvalho da Silveira', 5467657565, '2002-10-08', '2022-05-27', 'eric@gmail.com', '999422317', 'M', '89500000', 'Rua Tenente', 2306, 'Bom Retiro', 'Joinville', 'Santa Catarina', 1, '2022-05-10', 1, 1, 90),
(12, 0, 'Lucas Gonçalves Brach', 12345678912, '2002-08-30', '2022-07-22', 'conan@gmail.com', '479089422316', 'M', '89232100', 'Não Sei', 10, 'Não Sei', 'Joinville', 'Santa Catarina', 1, '2022-03-10', 1, 1, 200);

-- --------------------------------------------------------

--
-- Estrutura da tabela `planos`
--

CREATE TABLE `planos` (
  `id` int(11) NOT NULL,
  `nome` varchar(30) NOT NULL,
  `preco` float NOT NULL,
  `duracao` int(11) NOT NULL,
  `descricao` varchar(200) DEFAULT NULL,
  `desconto` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `planos`
--

INSERT INTO `planos` (`id`, `nome`, `preco`, `duracao`, `descricao`, `desconto`) VALUES
(1, 'Plano 1', 90, 60, 'descricao plano', 10);

-- --------------------------------------------------------

--
-- Estrutura da tabela `professores`
--

CREATE TABLE `professores` (
  `codigo` int(11) NOT NULL,
  `salario` float NOT NULL,
  `nome` varchar(50) NOT NULL,
  `cpf` bigint(11) NOT NULL,
  `datanasc` date NOT NULL,
  `data_cadastro` date NOT NULL,
  `email` varchar(50) NOT NULL,
  `celular` varchar(15) NOT NULL,
  `sexo` varchar(15) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numero` int(11) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `cidade` varchar(50) NOT NULL,
  `estado` varchar(50) NOT NULL,
  `instrutor` tinyint(1) DEFAULT NULL,
  `personal` tinyint(1) DEFAULT NULL,
  `professor` tinyint(1) DEFAULT NULL,
  `turno` varchar(50) DEFAULT NULL,
  `codigo_unidade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `professores`
--

INSERT INTO `professores` (`codigo`, `salario`, `nome`, `cpf`, `datanasc`, `data_cadastro`, `email`, `celular`, `sexo`, `cep`, `rua`, `numero`, `bairro`, `cidade`, `estado`, `instrutor`, `personal`, `professor`, `turno`, `codigo_unidade`) VALUES
(1, 2000, 'Jonas Moreira', 6501617936, '2002-10-08', '2022-05-27', 'eric.avaiano@gmail.com', '999422317', 'M', '89500000', 'Rua Tenente', 2306, 'Bom Retiro', 'Joinville', 'Santa Catarina', 1, 0, 1, '12h - 15h', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `treinos`
--

CREATE TABLE `treinos` (
  `id` int(11) NOT NULL,
  `objetivo` varchar(20) NOT NULL,
  `data_inicio` date NOT NULL,
  `duracao` float NOT NULL,
  `observacoes` varchar(200) NOT NULL,
  `matricula` int(11) NOT NULL,
  `codigo_professor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `treinos`
--

INSERT INTO `treinos` (`id`, `objetivo`, `data_inicio`, `duracao`, `observacoes`, `matricula`, `codigo_professor`) VALUES
(15, 'Ficar gigante', '2022-07-19', 60, 'Fortificar panturrilha', 6, 1),
(17, 'Hipertrofia', '2022-07-22', 100, 'Elevação de Carga', 12, 1),
(18, 'Ombro Maior do Mundo', '2022-07-23', 45, 'SÓ OMBRO', 12, 1),
(20, 'Novo treino', '2022-07-23', 60, 'novo', 12, 1),
(21, 'Ficar forte', '2022-07-24', 90, 'Foco em peito', 6, 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `unidades`
--

CREATE TABLE `unidades` (
  `codigo` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `site` varchar(100) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  `cep` varchar(10) NOT NULL,
  `rua` varchar(50) NOT NULL,
  `numero` int(11) NOT NULL,
  `bairro` varchar(50) NOT NULL,
  `cidade` varchar(50) NOT NULL,
  `estado` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `unidades`
--

INSERT INTO `unidades` (`codigo`, `nome`, `site`, `telefone`, `email`, `cep`, `rua`, `numero`, `bairro`, `cidade`, `estado`) VALUES
(1, 'Unidade 1', 'uni1.com.br', '499999', 'u1@gmail.com', '89500000', 'Rua Tenente', 2306, 'Bom Retiro', 'Joinville', 'Santa Catarina');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `alunos`
--
ALTER TABLE `alunos`
  ADD PRIMARY KEY (`matricula`),
  ADD KEY `alunos1` (`codigo_unidade`),
  ADD KEY `alunos2` (`id_plano`),
  ADD KEY `alunos3` (`codigo_professor`);

--
-- Índices para tabela `planos`
--
ALTER TABLE `planos`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `professores`
--
ALTER TABLE `professores`
  ADD PRIMARY KEY (`codigo`),
  ADD KEY `professores1` (`codigo_unidade`);

--
-- Índices para tabela `treinos`
--
ALTER TABLE `treinos`
  ADD PRIMARY KEY (`id`) USING BTREE,
  ADD KEY `treinos1` (`codigo_professor`),
  ADD KEY `treinos2` (`matricula`);

--
-- Índices para tabela `unidades`
--
ALTER TABLE `unidades`
  ADD PRIMARY KEY (`codigo`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `alunos`
--
ALTER TABLE `alunos`
  MODIFY `matricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT de tabela `planos`
--
ALTER TABLE `planos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `professores`
--
ALTER TABLE `professores`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `treinos`
--
ALTER TABLE `treinos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de tabela `unidades`
--
ALTER TABLE `unidades`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `alunos`
--
ALTER TABLE `alunos`
  ADD CONSTRAINT `alunos1` FOREIGN KEY (`codigo_unidade`) REFERENCES `unidades` (`codigo`),
  ADD CONSTRAINT `alunos2` FOREIGN KEY (`id_plano`) REFERENCES `planos` (`id`),
  ADD CONSTRAINT `alunos3` FOREIGN KEY (`codigo_professor`) REFERENCES `professores` (`codigo`);

--
-- Limitadores para a tabela `professores`
--
ALTER TABLE `professores`
  ADD CONSTRAINT `professores1` FOREIGN KEY (`codigo_unidade`) REFERENCES `unidades` (`codigo`);

--
-- Limitadores para a tabela `treinos`
--
ALTER TABLE `treinos`
  ADD CONSTRAINT `treinos1` FOREIGN KEY (`codigo_professor`) REFERENCES `professores` (`codigo`),
  ADD CONSTRAINT `treinos2` FOREIGN KEY (`matricula`) REFERENCES `alunos` (`matricula`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
