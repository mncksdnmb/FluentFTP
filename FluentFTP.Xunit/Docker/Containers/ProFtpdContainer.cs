﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace FluentFTP.Xunit.Docker.Containers {
	internal class ProFtpdContainer : DockerFtpContainer {

		public ProFtpdContainer() {
			Type = FtpServer.ProFTPD;
			ServerType = "proftpd";
			DockerImage = "kibatic/proftpd";
			DockerGithub = "https://github.com/kibatic/docker-proftpd";
			//RunCommand = "docker run -d --net host -e FTP_LIST=\"fluentroot:fluentpass\" -e MASQUERADE_ADDRESS=1.2.3.4 proftpd:fluentftp";
			//FtpUser = "fluentroot";
			//FtpPass = "fluentpass";
		}

		/// <summary>
		/// For help creating this section see https://github.com/testcontainers/testcontainers-dotnet#supported-commands
		/// </summary>
		public override void Configure(ITestcontainersBuilder<TestcontainersContainer> builder) {

			ExposePortRange(builder, 50000, 50100);

			builder
				.WithEnvironment("FTP_LIST", DockerFtpConfig.FtpUser + ":" + DockerFtpConfig.FtpPass)
				.WithEnvironment("PASSIVE_MIN_PORT", "50000")
				.WithEnvironment("PASSIVE_MAX_PORT", "50100")
				.WithEnvironment("MASQUERADE_ADDRESS", "1.2.3.4");

		}
	}
}
