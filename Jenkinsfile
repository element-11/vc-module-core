node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat "\"${tool 'Nuget'}\" restore VirtoCommerce.CoreModule.sln"
		bat "\"${tool 'MSBuild 12.0'}\" VirtoCommerce.CoreModule.sln /p:Configuration=Debug /p:Platform=\"Any CPU\""
		
	if (env.BRANCH_NAME == 'master') {
		stage 'Nuget Package'
			dir('nuget') {
		   		bat 'build.bat'
			}
			
	}
}
