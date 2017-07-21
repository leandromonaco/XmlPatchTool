Feature: Scenarios
	In order to compare 2 xml files
	As a developer
	I want to be told the xml differences

@XmlPatchTool
Scenario Outline: Compare 2 XML files
	Given I use file <File1> And <File2>
	When I compare xml files
	Then the Node Additions should be <NodeAdditionsValue>
	And  the Node or Text Removals should be <NodeOrTextRemovalsValue>
	And  the Node Changes should be <NodeChangesValue>
	And  the Attribute Additions should be <AttributeAdditionsValue>
	And  the Attribute Removals should be <AttributeRemovalsValue>
	And  the Attribute Changes should be <AttributeChangesValue>
	And  the Text Additions should be <TextAdditionsValue>
	And  the Text Changes should be <TextChangesValue>
	And  Changes flag should be <ChangesFlag>
Examples:
		| File1					| File2										| NodeAdditionsValue	| NodeOrTextRemovalsValue	| NodeChangesValue  | AttributeAdditionsValue	| AttributeRemovalsValue	| AttributeChangesValue | TextAdditionsValue	|TextChangesValue		| ChangesFlag	|
		| FileA.xml				| FileA.xml									| 0						| 0							| 0					| 0							| 0							| 0						| 0						|0						| false			|
		| FileA.xml				| FileA_NodeChange.xml						| 0						| 0							| 3					| 0							| 0							| 0						| 0						|0						| true			|
		| FileA.xml				| FileA_AttributeChange.xml					| 0						| 0							| 0					| 0							| 0							| 10					| 0						|0						| true			|
		| FileA.xml				| FileA_TextChange.xml						| 0						| 0							| 0					| 0							| 0							| 0						| 0						|3						| true			|		
		| FileA.xml				| FileA_NodeAttributeTextChange1.xml		| 0						| 0							| 4					| 0							| 0							| 3						| 0						|2						| true			|		
		| FileA.xml				| FileA_AttributeRemoval.xml				| 0						| 0							| 0					| 0							| 10						| 0						| 0						|0						| true			|		
		| FileA.xml				| FileA_NodeRemoval.xml						| 0						| 2							| 0					| 0							| 0							| 0						| 0						|0						| true			|		
		| FileA.xml				| FileA_TextRemoval.xml						| 0						| 2							| 0					| 0							| 0							| 0						| 0						|0						| true			|		
		| FileA.xml				| FileA_NodeOrTextRemoval.xml				| 0						| 3							| 0					| 0							| 0							| 0						| 0						|0						| true			|		

		


