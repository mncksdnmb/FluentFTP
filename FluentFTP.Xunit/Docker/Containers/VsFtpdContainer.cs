﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace FluentFTP.Xunit.Docker.Containers {
	internal class VsFtpdContainer : DockerFtpContainer {

		public VsFtpdContainer() {
			Type = FtpServer.VsFTPd;
			ServerType = "vsftpd";
			DockerImage = "fauria/vsftpd";
			DockerGithub = "https://github.com/fauria/docker-vsftpd";
			//RunCommand = "docker run --rm -it -p 21:21 -p 4559-4564:4559-4564 -e FTP_USER=fluentroot -e FTP_PASSWORD=fluentpass vsftpd:fluentftp";
			//FtpUser = "fluentroot";
			//FtpPass = "fluentpass";
		}

		/// <summary>
		/// For help creating this section see https://github.com/testcontainers/testcontainers-dotnet#supported-commands
		/// </summary>
		public override void Configure(ITestcontainersBuilder<TestcontainersContainer> builder) {

			builder.WithPortBinding(20)
				.WithPortBinding(21);

			ExposePortRange(builder, 21100, 21110);

			builder
				.WithEnvironment("PASV_ADDRESS", "127.0.0.1")
				.WithEnvironment("FTP_USER", DockerFtpConfig.FtpUser)
				.WithEnvironment("FTP_PASS", DockerFtpConfig.FtpPass);

		}

	}
}
