﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace FluentFTP.Xunit.Docker.Containers {
	internal class PureFtpdContainer : DockerFtpContainer {

		public PureFtpdContainer() {
			Type = FtpServer.PureFTPd;
			ServerType = "pureftpd";
			DockerImage = "stilliard/pure-ftpd";
			DockerGithub = "https://github.com/stilliard/docker-pure-ftpd";
			//RunCommand = "docker run -d --name ftpd_server -p 21:21 -p 30000-30009:30000-30009 -e \"PUBLICHOST=localhost\" -e \"FTP_USER_NAME=fluentroot\" -e \"FTP_USER_PASS=fluentpass\" pureftpd:fluentftp";
			//FtpUser = "fluentroot";
			//FtpPass = "fluentpass";
		}

		/// <summary>
		/// For help creating this section see https://github.com/testcontainers/testcontainers-dotnet#supported-commands
		/// </summary>

		public override void Configure(ITestcontainersBuilder<TestcontainersContainer> builder) {

			ExposePortRange(builder, 30000, 30009);

			builder
				.WithEnvironment("FTP_USER_NAME", DockerFtpConfig.FtpUser)
				.WithEnvironment("FTP_USER_PASS", DockerFtpConfig.FtpPass)
				.WithEnvironment("FTP_USER_HOME", "/home/bob");

		}

	}
}